using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace RealtimeDataSystem.GrpcService.Services;

// help resource https://docs.microsoft.com/en-us/aspnet/core/grpc/services?view=aspnetcore-6.0

public class StockService : Stock.StockBase
{
    private readonly ILogger<StockService> logger;
    private readonly Random rand;

    public StockService(ILogger<StockService> logger)
    {
        this.logger = logger;
        rand = new Random();
    }

    public override Task<QuoteReply> GetQuote(QuoteRequest request, ServerCallContext context)
    {
        logger.LogInformation($"Quote Requested: {request.Ticker}");

        return Task.FromResult(new QuoteReply
        {
            Ticker = request.Ticker,
            Quote = rand.NextDouble() * 1000,
            QuoteTime = Timestamp.FromDateTime(DateTime.UtcNow)
        });
    }

    public override Task<TransactionReply> BuyOrder(BuyRequest request, ServerCallContext context)
    {
        logger.LogInformation($"Put Order Requested: {request.Ticker}, Price: {request.Quote}");

        var currentPrice = rand.NextDouble() * 1000;

        // For buying a stock, the transaction is successful if:
        // the current price of the stock is equal to (or lower) than the quote (what they want to buy at.. never higher)
        var saleMade = request.Quote <= currentPrice;

        // for simplicity, this is a 'buy all or none' order type
        var saleCost = saleMade ? currentPrice * request.Quantity : 0;

        return Task.FromResult(new TransactionReply
        {
            Ticker = request.Ticker,
            TransactionConfirmed = saleMade,
            Quantity = saleMade ? request.Quantity : 0,
            Price = saleCost
        });
    }

    public override Task<TransactionReply> SellOrder(SellRequest request, ServerCallContext context)
    {
        logger.LogInformation($"Put Order Requested: {request.Ticker}, Price: {request.Quote}");

        var currentPrice = rand.NextDouble() * 1000;

        // For selling a stock, the transaction is successful if:
        // the current price of the stock is equal to (or higher) than the quote (what they want to sell at... never lower)
        var saleMade = request.Quote >= currentPrice;

        // for simplicity, this is a sell 'all or none' order type
        var saleCost = saleMade ? currentPrice * request.Quantity : 0;

        return Task.FromResult(new TransactionReply
        {
            Ticker = request.Ticker,
            TransactionConfirmed = saleMade,
            Quantity = saleMade ? request.Quantity : 0,
            Price = saleCost
        });
    }
}