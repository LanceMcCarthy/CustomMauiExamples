using CommonHelpers.Collections;
using CommonHelpers.Common;
using CommonHelpers.Models;
using CommonHelpers.Services;

namespace DepndInjtnDemo.ViewModels;

public class ProductsViewModel : ViewModelBase
{
    public ProductsViewModel()
    {
    }

    public ObservableRangeCollection<Product> Products => new(SampleDataService.Current.GenerateProductData());
}