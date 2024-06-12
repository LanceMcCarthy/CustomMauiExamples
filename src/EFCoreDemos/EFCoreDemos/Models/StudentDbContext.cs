using Microsoft.EntityFrameworkCore;

namespace EFCoreDemos.Models;

public class StudentDbContext(DbContextOptions<StudentDbContext> options) : DbContext(options)
{
    private readonly string dbPath = Path.Join(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "students.db");

    public DbSet<StudentEntity> Students { get; set; }

    // Called in app.cs
    public async Task InitializeDatabaseAsync()
    {
        await this.Database.EnsureCreatedAsync();

        if (!this.Students.Any())
        {
            var rand = new Random();

            for (var i = 0; i < 2000; i++)
            {
                this.Students.Add(new StudentEntity
                {
                    FullName = $"StudentEntity {i + 1}",
                    Grade = rand.Next(1, 13)
                });
            }
        }

        await this.SaveChangesAsync();
    }

    // Called in app.cs
    public void InitializeDatabase()
    {
        this.Database.EnsureCreated();

        if (!this.Students.Any())
        {
            var rand = new Random();

            for (var i = 0; i < 2000; i++)
            {
                this.Students.Add(new StudentEntity
                {
                    FullName = $"StudentEntity {i + 1}",
                    Grade = rand.Next(1, 13)
                });
            }
        }

        this.SaveChanges();
    }

    // create a Sqlite database file in the local app data folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite($"Data Source={dbPath}");
}
