using CommonHelpers.Mvvm;
using FlyoutExample.Models;
using FlyoutExample.Views;

namespace FlyoutExample.ViewModels;

public class RouteDetailPageViewModel : PageViewModel
{
    private Pilot selectedPilot;

    public RouteDetailPageViewModel()
    {
        SaveCommand = new DelegateCommand(Save);
        GoBackCommand = new DelegateCommand(GoBack);
        ResetCommand = new DelegateCommand(Reset);
    }

    public Pilot SelectedPilot
    {
        get => selectedPilot;
        set => SetProperty(ref selectedPilot, value);
    }

    public DelegateCommand SaveCommand { get; set; }

    public DelegateCommand GoBackCommand { get; set; }

    public DelegateCommand ResetCommand { get; set; }

    // Start - API Values for ListPickers (these are the only values available from the API)

    public List<string> Genders => new() { "male", "female" };

    public List<string> Ethnicities => new() { "white", "latino", "asian", "black" };

    public List<string> EyeColors => new() { "brown", "blue", "gray", "green" };

    public List<string> HairColors => new() { "brown", "blond", "black", "gray", "red" };

    public List<string> HairLengths => new() { "short", "medium", "long" };

    // End - API values
    
    private void Save()
    {
        (Application.Current as App).RouteService.UpdatePilotAsync(this.SelectedPilot);
    }

    private async void GoBack()
    {
        await ((Application.Current.MainPage as MyRootPage).Detail as NavigationPage)?.PopAsync();
    }

    private void Reset()
    {
        OnPropertyChanged(nameof(SelectedPilot));
    }

    public override void OnPageAppearing()
    {

    }
}
