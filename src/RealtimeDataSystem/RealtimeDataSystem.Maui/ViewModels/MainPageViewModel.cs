using CommonHelpers.Common;
using Grpc.Net.Client;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace RealtimeDataSystem.Maui.ViewModels;

public class MainPageViewModel : ViewModelBase
{
    private GrpcChannel channel;
    private Grpc.Stock.StockClient client;
    private Grpc.QuoteReply latestQuoteReply;
    private string selectedTransactionType;
    private string tickerSymbol;
    private double requestedPrice;
    private int requestedQuantity;

    public MainPageViewModel()
    {
        TransactionReplies = new();
        TransactionTypes = new() { "QUOTE", "BUY", "SELL" };
        MakeRequestCommand = new (MakeRequest);

        // some defaults to play with
        SelectedTransactionType = TransactionTypes[0];
        TickerSymbol = "MSFT";
        RequestedPrice = 289;
        RequestedQuantity = 1;
    }

    public ObservableCollection<Grpc.TransactionReply> TransactionReplies { get; }

    public List<string> TransactionTypes { get; }

    public Command MakeRequestCommand { get; set; }

    public Grpc.QuoteReply LatestQuoteReply
    {
        get => latestQuoteReply;
        set => SetProperty(ref latestQuoteReply, value);
    }

    public string SelectedTransactionType
    {
        get => selectedTransactionType;
        set => SetProperty(ref selectedTransactionType, value);
    }

    public string TickerSymbol
    {
        get => tickerSymbol;
        set => SetProperty(ref tickerSymbol, value);
    }

    public double RequestedPrice
    {
        get => requestedPrice;
        set => SetProperty(ref requestedPrice, value);
    }

    public int RequestedQuantity
    {
        get => requestedQuantity;
        set => SetProperty(ref requestedQuantity, value);
    }
    
    private async void MakeRequest(object obj)
    {
        try
        {
            IsBusyMessage = $"Making {SelectedTransactionType} request for {TickerSymbol}.";

            if (SelectedTransactionType == TransactionTypes[0])
            {
                Grpc.QuoteRequest quoteRequest = new()
                {
                    Ticker = TickerSymbol
                };

                LatestQuoteReply = await client.GetQuoteAsync(quoteRequest);
            }
            else if (SelectedTransactionType == TransactionTypes[1])
            {
                Grpc.BuyRequest buyRequest = new()
                {
                    Ticker = TickerSymbol,
                    Quote = RequestedPrice,
                    Quantity = RequestedQuantity
                };

                var response = await client.BuyOrderAsync(buyRequest);

                TransactionReplies.Add(response);
            }
            else if (SelectedTransactionType == TransactionTypes[2])
            {
                Grpc.SellRequest sellRequest = new()
                {
                    Ticker = TickerSymbol,
                    Quote = RequestedPrice,
                    Quantity = RequestedQuantity
                };

                var response = await client.SellOrderAsync(sellRequest);

                TransactionReplies.Add(response);
            }

            IsBusyMessage = $"Request complete. Last response {DateTime.Now:T}";
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            IsBusyMessage = $"Error {ex.Message}.";
        }
    }
    
    public void ConnectToGrpcServices()
    {
        IsBusy = true;
        IsBusyMessage = "Connecting to gRPC service...";
        
        channel = GrpcChannel.ForAddress("http://localhost:5243/");
        client = new Grpc.Stock.StockClient(channel);

        IsBusyMessage = "ready to connect";
        IsBusy = false;
    }
}
