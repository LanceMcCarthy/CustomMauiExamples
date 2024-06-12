using CommonHelpers.Common;
using CommonHelpers.Extensions;
using EFCoreDemos.Models;
using Telerik.Maui;

namespace EFCoreDemos.ViewModels;

public class MainPageViewModel : ViewModelBase
{
    private readonly StudentDbContext dbContext;
    private readonly int itemsPerPage = 50;
    private int pageToGet;

    public MainPageViewModel(StudentDbContext dbService)
    {
        dbContext = dbService;

        DataGridStudents = new LoadOnDemandCollection<StudentEntity>(FetchData);

        DataGridStudents.AddRange(FetchData(default));
    }

    public LoadOnDemandCollection<StudentEntity> DataGridStudents { get; set; }

    private IEnumerable<StudentEntity> FetchData(CancellationToken token)
    {
        try
        {
            // Get next page of data using the offset and count
            var nextPageOfData = dbContext.Students.Skip(itemsPerPage * pageToGet).Take(itemsPerPage);

            pageToGet++;

            return nextPageOfData;
        }
        catch
        {
            // Return an empty list to stop loading
            return new List<StudentEntity>();
        }
    }

    // ***** IMPORTANT - EDITING CONSIDERATION ***** //
    // If you are making changes to the front-end data, this does not automatically insert the item to the database
    // For example, this task adds to both the Collection and the database
    // public async Task AddNewStudentAsync(StudentEntity student)
    // {
    //     (FRONT END DATA)
    //    // Step 1 - add it to the UI  (FRONT END DATA)
    //    DataGridStudents.Add(student);
    //
    //     (DATABASE DATA !!!)
    //    // Step 2 - Add it to the database
    //    dbContext.Students.Add(student);
    //
    //    // Step 3 - Save the database changes
    //    await dbContext.SaveChangesAsync();
    // }
}