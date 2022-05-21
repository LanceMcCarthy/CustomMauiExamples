using CommonHelpers.Mvvm;
using FlyoutExample.Models;
using FlyoutExample.Views;
using System.Collections.ObjectModel;

namespace FlyoutExample.ViewModels
{
    public class RoutesPageViewModel : PageViewModel
    {
        private ObservableCollection<Pilot> routes = new ();

        public RoutesPageViewModel()
        {
            GoToDetailsCommand = new DelegateCommand<Pilot>(GoToDetails);
            DeleteCommand = new DelegateCommand<Pilot>(Delete);
        }

        public ObservableCollection<Pilot> Routes
        {
            get => routes;
            set => SetProperty(ref routes, value);
        }

        public DelegateCommand<Pilot> GoToDetailsCommand { get; set; }

        public DelegateCommand<Pilot> DeleteCommand { get; set; }

        private async void GoToDetails(Pilot pilot)
        {
            var page = new RouteDetailPage
            {
                BindingContext = new RouteDetailPageViewModel{SelectedPilot = pilot}
            };

            await ((Application.Current.MainPage as MyRootPage).Detail as NavigationPage).PushAsync(page);
        }

        private async void Delete(Pilot pilot)
        {
            var result = await (Application.Current as App).RouteService.RemovePilotAsync(pilot);

            if (result)
            {
                Routes.Remove(pilot);
            }
        }

        public override async void OnPageAppearing()
        {
            if (Routes.Any())
                return;

            IsBusy = true;
            IsBusyMessage = "loading route pilot data...";
            
            var cache = await (Application.Current as App).RouteService.GetPilotsAsync();
            
            Routes = new ObservableCollection<Pilot>(cache);

            IsBusy = false;
            IsBusyMessage = string.Empty;
        }
    }
}
