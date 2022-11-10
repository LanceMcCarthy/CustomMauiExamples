using CommonHelpers.Collections;
using CommonHelpers.Common;
using CommonHelpers.Models;
using CommonHelpers.Services;

namespace DepndInjtnDemo.ViewModels;

public class MainViewModel : ViewModelBase
{
    public MainViewModel()
    {
        ReloadPeopleCommand = new Command(() =>
        {
            People.Clear();
            People.AddRange(SampleDataService.Current.GeneratePeopleData(true));
        });
    }

    public ObservableRangeCollection<Person> People => new(SampleDataService.Current.GeneratePeopleData(true));

    public ObservableRangeCollection<Product> Products => new(SampleDataService.Current.GenerateProductData());

    public Command ReloadPeopleCommand { get; set; }
}