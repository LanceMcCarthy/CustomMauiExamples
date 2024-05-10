namespace LantzControls.Views;

public partial class PartialRatingDemoPage : ContentPage
{
	public PartialRatingDemoPage()
	{
		InitializeComponent();
	}

    private void Button_OnClicked(object sender, EventArgs e)
    {
        var rating = Random.Shared.Next(0,5) + Random.Shared.NextDouble();

        RottenTomatoesRating.SetRating(rating);
    }
}