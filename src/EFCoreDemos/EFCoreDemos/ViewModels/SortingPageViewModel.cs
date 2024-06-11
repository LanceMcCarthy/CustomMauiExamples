using CommonHelpers.Common;
using CommonHelpers.Extensions;
using EFCoreDemos.Models;
using EFCoreDemos.Models.Tools;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using Telerik.Maui;
using Telerik.Maui.Controls.Data;

namespace EFCoreDemos.ViewModels;

public class SortingPageViewModel : ViewModelBase
{
    private ObservableCollection<SortDescriptorBase> studentSortDescriptors = new();
    private readonly StudentDbContext dbContext;
    private readonly int itemsPerPage = 50;
    private int pageToGet = 0;

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
    }

    private List<StudentEntity> GetNextPage()
    {
        IEnumerable<StudentEntity> nextPageOfData;

        try
        {
            IQueryable<StudentEntity> query = dbContext.Students.AsQueryable();

            // **** Phase 1 *** //
            // Check to see if there are any sort descriptors applied
            foreach (var descriptor in StudentSortDescriptors)
            {
                // If there is a PropertySortDescriptor, add that to the query
                if (descriptor is PropertySortDescriptor pDescriptor)
                {
                    var prop = typeof(StudentEntity).GetProperty(pDescriptor.PropertyName);

                    query = descriptor.SortOrder == SortOrder.Descending 
                        ? query.OrderByDescending(student => prop.GetValue(student, null))
                        : query.OrderBy(student => prop.GetValue(student, null));
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

            // **** Phase 2 *** //
            // Handle Skip and Take

            // Skips the pages you've already fetched
            query = query.Skip(itemsPerPage * pageToGet);

            // Takes the next page of items
            query = query.Take(itemsPerPage);


            // **** Phase 3 *** //
            // Execute the query and return the results

            // Invoking ToList() forces LINQ to combine the expression and get results now.
            nextPageOfData = query.ToList();

            pageToGet++;
        }
        catch
        {
            // Return an empty list to stop loading
            nextPageOfData = new List<StudentEntity>();
        }
        
        return nextPageOfData.ToList();
    }

    public async Task OnAppearing()
    {
        await dbContext.InitializeDatabaseAsync();

        if (!dbContext.Students.Any())
            await GenerateSampleRows();

        // Load first batch to get started.
        DataGridStudents.AddRange(GetNextPage());
    }

    private async Task GenerateSampleRows()
    {
        for (var i = 0; i < 2000; i++)
        {
            dbContext.Students.Add(new StudentEntity
            {
                FullName = $"StudentEntity {i+1}",
                Grade = i % 2 == 0 ? 11 : 12
            });
        }

        await dbContext.SaveChangesAsync();
    }


    
    // ***** EDITING CONSIDERATION ***** //
    // Important - If you are making changes to the front-end data, do not forget to update the backend data (i.e. database), too.
    // For example, adding a new Student:
    // public async Task AddNewStudentAsync(StudentEntity student)
    // {
    //     (FRONT END DATA)
    //    // Step 1 - add it to the UI  (FRONT END DATA)
    //    DataGridStudents.Add(student);
    //
    //     (BACK END DATA !!!)
    //    // Step 2 - Add it to the database
    //    dbContext.Students.Add(student);
    //
    //    // Step 3 - Save the database changes
    //    await dbContext.SaveChangesAsync();
    // }
}