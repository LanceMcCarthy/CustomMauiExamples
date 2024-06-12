using CommonHelpers.Common;
using CommonHelpers.Extensions;
using EFCoreDemos.Models;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using EFCoreDemos.Models.Tools;
using Telerik.Maui;
using Telerik.Maui.Controls.Data;

namespace EFCoreDemos.ViewModels;

public class SortingPageViewModel : ViewModelBase
{
    private ObservableCollection<SortDescriptorBase> studentSortDescriptors = new();
    private readonly StudentDbContext dbContext;
    private readonly int itemsPerPage = 50;
    private int pageToGet;

    public SortingPageViewModel(StudentDbContext dbService)
    {
        dbContext = dbService;

        DataGridStudents = new LoadOnDemandCollection<StudentEntity>((token) => GetNextPage());
    }

    public LoadOnDemandCollection<StudentEntity> DataGridStudents { get; set; }

    public ObservableCollection<SortDescriptorBase> StudentSortDescriptors
    {
        get => studentSortDescriptors;
        set
        {
            // Unsubscribe from CollectionChanged
            studentSortDescriptors.CollectionChanged -= SortDescriptors_CollectionChanged;

            // update backing field
            studentSortDescriptors = value;

            // Resubscribe to CollectionChanged
            studentSortDescriptors.CollectionChanged += SortDescriptors_CollectionChanged;

            OnPropertyChanged();
        }
    }

    private void SortDescriptors_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs args)
    {
        UpdateDataAfterSortChange();
    }

    private void UpdateDataAfterSortChange()
    {
        if(pageToGet==0) return;

        DataGridStudents.AddRange(GetNextPage());
    }

    private IEnumerable<StudentEntity> GetNextPage()
    {
        try
        {
            IQueryable<StudentEntity> query = dbContext.Students.AsQueryable();

            // **** Phase 1 *** //
            // Check to see if there are any sort descriptors applied
            HandleSortQueries(ref query);

            // **** Phase 2 *** //
            // Handle Skip and Take

            // Skips the pages you've already fetched
            query = query.Skip(itemsPerPage * pageToGet);

            // Takes the next page of items
            query = query.Take(itemsPerPage);


            // **** Phase 3 *** //
            // Execute the query by invoking ToList()
            var nextPageOfData = query.ToList();

            pageToGet++;

            return nextPageOfData;
        }
        catch
        {
            // Return an empty list to stop loading
            return new List<StudentEntity>();
        }
    }

    private void HandleSortQueries(ref IQueryable<StudentEntity> query)
    {
        foreach (var descriptor in StudentSortDescriptors)
        {
            // If there is a PropertySortDescriptor, add that to the query
            if (descriptor is PropertySortDescriptor pDescriptor)
            {
                var prop = typeof(StudentEntity).GetProperty(pDescriptor.PropertyName);

                query = descriptor.SortOrder == SortOrder.Descending 
                    ? query.OrderByDescending(student => prop!.GetValue(student, null))
                    : query.OrderBy(student => prop!.GetValue(student, null));
            }

            // If there is a DelegateSortDescriptor, add it to the query
            if (descriptor is DelegateSortDescriptor dDescriptor)
            {
                query = descriptor.SortOrder == SortOrder.Descending 
                    ? query.OrderByDescending(x => dDescriptor.KeyLookup.GetKey(x))
                    : query.OrderBy(x => dDescriptor.KeyLookup.GetKey(x));
            }

            // Finally, pass along the IComparer using a class that converts between different IComparer types
            query = descriptor.SortOrder == SortOrder.Descending 
                ? query.OrderDescending(new AdaptorComparer<StudentEntity>(descriptor.Comparer))
                : query.Order(new AdaptorComparer<StudentEntity>(descriptor.Comparer));
        }
    }

    public Task OnAppearing()
    {
        // Load first batch to get started.
        DataGridStudents.AddRange(GetNextPage());

        return Task.CompletedTask;
    }
}