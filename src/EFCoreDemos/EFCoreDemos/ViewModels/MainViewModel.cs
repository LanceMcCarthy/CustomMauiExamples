using CommonHelpers.Common;
using CommonHelpers.Extensions;
using EFCoreDemos.Models;
using Telerik.Maui.Controls.Compatibility.Common;

namespace EFCoreDemos.ViewModels;

public class MainViewModel : ViewModelBase
{
    private readonly StudentDbContext dbContext;
    private readonly int itemsPerPage = 50;
    private int pageToGet = 0;

    public MainViewModel(StudentDbContext dbService)
    {
        dbContext = dbService;

        // 1. Setup on-demand
        DataGridStudents = new LoadOnDemandCollection<StudentEntity>((token) => GetNextPage());

        // 2. Load first batch to get started.
        var firstPage = GetNextPage();

        DataGridStudents.AddRange(firstPage);
    }

    public LoadOnDemandCollection<StudentEntity> DataGridStudents { get; set; }

    private IEnumerable<StudentEntity> GetNextPage()
    {
        var nextPageOfData = dbContext.Students.Skip(itemsPerPage * pageToGet).Take(itemsPerPage);

        pageToGet++;

        // WARNING - Make sure you are not trying to fetch pages that don't exist (out of range/bounds exception).
        // Once you reach the end of the data, just return an empty result and automatic load on demand will turn off.
        return nextPageOfData;
    }

    // Important - If you are making changes to the front-end data, do not forget to update the backend data (i.e. database), too.
    //public async Task AddNewStudentAsync(StudentEntity student)
    //{
    //     (FRONT END DATA)
    //    // Step 1 - add it to the UI  (FRONT END DATA)
    //    DataGridStudents.Add(student);

    //     (BACK END DATA)
    //    // Step 2 - Add it to the database
    //    dbContext.Students.Add(student);

    //    // Step 3 - Save the database changes
    //    await dbContext.SaveChangesAsync();
    //}
}
