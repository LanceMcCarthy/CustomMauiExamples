using CommonHelpers.Collections;
using CommonHelpers.Common;
using CommonHelpers.Models;
using CommonHelpers.Services;

namespace DepndInjtnDemo.ViewModels;

public class PeopleViewModel : ViewModelBase
{
    public PeopleViewModel()
    {
        ReloadPeopleCommand = new Command(() =>
        {
            People.Clear();
            People.AddRange(SampleDataService.Current.GeneratePeopleData(true));
        });
    }

    public ObservableRangeCollection<Person> People => new(SampleDataService.Current.GeneratePeopleData(true));

    public Command ReloadPeopleCommand { get; set; }
}
