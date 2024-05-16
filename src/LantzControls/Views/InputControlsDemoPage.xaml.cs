using System.Diagnostics;
using LantzControls.Input.Models;

namespace LantzControls.Views;

public partial class InputControlsDemoPage : ContentPage
{
	public InputControlsDemoPage()
	{
		InitializeComponent();

        MySegmentView.ItemsSource = [
            new SegmentItem() { Text = "Breakfast", ImageSource = ImageSource.FromFile("breakfast.png") },
            new SegmentItem() { Text = "Lunch", ImageSource = ImageSource.FromFile("lunch.png") },
            new SegmentItem() { Text = "Dinner", ImageSource = ImageSource.FromFile("dinner.png") }
        ];
    }

    private void ButtonSegments_OnSelectedItemChanged(object sender, SelectedItemChangedEventArgs e)
    {
        Debug.WriteLine($"You have selected: {((SegmentItem)e.SelectedItem).Text}");
    }

    private void PartialRatingButton_OnClicked(object sender, EventArgs e)
    {
        var rating = Random.Shared.Next(0,5) + Random.Shared.NextDouble();
        RottenTomatoesRating.SetRating(rating);
    }
}