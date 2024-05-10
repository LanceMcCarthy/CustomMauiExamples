namespace LantzControls.Input;

public partial class PartialRating : ContentView
{
    // NOTE: change these to public BindableProperties in a real-world situation.
    private double rating;
    private double maximumRating;
    private double itemWidth;
    private double itemHeight;
    private Color itemColor;
    private Color itemBackgroundColor;

    public PartialRating()
    {
        itemHeight = 40;
        itemWidth = 40;
        itemColor = Colors.DarkGreen;
        itemBackgroundColor = Colors.PaleGreen;
        maximumRating = 7;
        rating = 4.5;

        InitializeComponent();

        GenerateItems();
    }

    public void SetRating(double value)
    {
        this.rating = value;
        this.GenerateItems();
    }

    private void GenerateItems()
    {
        if (this.maximumRating == 0)
            throw new Exception($"{nameof(maximumRating)} must have a value greater than 0.");
        if (this.itemHeight == 0)
            throw new Exception($"{nameof(itemHeight)} must have a value greater than 0.");
        if (this.itemWidth == 0)
            throw new Exception($"{nameof(itemWidth)} must have a value greater than 0.");

        // Clear any previous renderings
        if (this.ItemsPanel.Children.Any())
            this.ItemsPanel.Children.Clear();

        // Calculate the number of filled shapes
        int wholeComponent = Convert.ToInt32(Math.Floor(this.rating));

        // Calculate the number of unfilled shapes
        int emptyComponent = Convert.ToInt32(Math.Floor(this.maximumRating - rating));

        // Calculate the percentage of fill for the partial shape
        double partialItemWidth = this.itemWidth * (this.rating %= 1);


        // Phase 1 - draw filled shapes

        for (int i = 1; i <= wholeComponent; i++)
        {
            this.ItemsPanel.Children.Add(new Grid
            {
                WidthRequest = this.itemHeight,
                HeightRequest = this.itemWidth,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                BackgroundColor = this.itemColor
            });
        }

        // Phase 2 - draw partial shape

        // The parent item, using ItemBackgroundColor
        var partialItem = new Grid
        {
            VerticalOptions = LayoutOptions.Center,
            HorizontalOptions = LayoutOptions.Center,
            WidthRequest = this.itemHeight,
            HeightRequest = this.itemWidth,
            BackgroundColor = this.itemBackgroundColor
        };

        // The child item that renders the partial fill using the ItemColor
        partialItem.Children.Add(new Grid
        {
            HorizontalOptions = LayoutOptions.Start,
            BackgroundColor = this.itemColor,
            HeightRequest = this.itemHeight,
            WidthRequest = partialItemWidth // this partially fills the shape according to the decimal
        });

        this.ItemsPanel.Children.Add(partialItem);


        // phase 3 - draw empty shapes

        for (int i = 1; i <= emptyComponent; i++)
        {
            this.ItemsPanel.Children.Add(new Grid
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                WidthRequest = this.itemHeight,
                HeightRequest = this.itemWidth,
                BackgroundColor = this.itemBackgroundColor
            });
        }
    }
}