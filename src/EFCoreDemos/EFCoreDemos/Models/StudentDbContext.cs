using Microsoft.EntityFrameworkCore;

namespace EFCoreDemos.Models;

public class StudentDbContext : DbContext
{
    private readonly string dbPath;

    public StudentDbContext(DbContextOptions<StudentDbContext> options)
        : base(options)
    {
        dbPath = Path.Join(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "student.db");
    }

    public DbSet<StudentEntity> Students { get; set; }

    // Important: this is called in app.xaml.cs. It's used to make sure the database exists and to add sample data for the cdemo
    public async Task InitializeDatabaseAsync()
    {
        await this.Database.EnsureCreatedAsync();
    }
    
    // create a Sqlite database file in the local app data folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={dbPath}");
}
