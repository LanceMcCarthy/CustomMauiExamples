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

        DataGridStudents = new LoadOnDemandCollection<StudentEntity>((token) => GetNextPage());
    }

    public LoadOnDemandCollection<StudentEntity> DataGridStudents { get; set; }

    private IEnumerable<StudentEntity> GetNextPage()
    {
        IEnumerable<StudentEntity> nextPageOfData;

        try
        {
            // Get next page of data using the offset and count
            nextPageOfData = dbContext.Students.Skip(itemsPerPage * pageToGet).Take(itemsPerPage);

            pageToGet++;
        }
        catch
        {
            // Return an empty list to stop loading
            nextPageOfData = new List<StudentEntity>();
        }
        
        return nextPageOfData;
    }

    public async Task OnAppearing()
    {
        await dbContext.InitializeDatabaseAsync();

        if (!dbContext.Students.Any())
            await GenerateSampleRows();

        // Load first batch to get started.
        DataGridStudents.AddRange(GetNextPage());
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
}
