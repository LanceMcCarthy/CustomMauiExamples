This project contains DataGrid with automatic load on demand, fetching data from a database using EntityFrameworkCore.

The main takeaway is the we're using the LoadOnDemandCollection to get the next page of data, and incrementing the page to fetch number.

```csharp
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
        // TAKEAWAY! - Use EnitityFramework to get the next page of data
        var nextPageOfData = dbContext.Students.Skip(itemsPerPage * pageToGet).Take(itemsPerPage);
        
        // Increment the page counter.
        pageToGet++;
        
        return nextPageOfData;
    }
}
```

and at runtime:

![datagrid and efcore](https://github.com/LanceMcCarthy/CustomMauiExamples/assets/3520532/1843f508-6fdb-48de-8b1f-657f0465d051)