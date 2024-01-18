using Microsoft.EntityFrameworkCore;
using Telerik.Maui.Controls.Chat;

namespace ChatDataSources.Maui.Models;

public class MessagesDbContext : DbContext
{
    private readonly string dbPath;

    public MessagesDbContext(DbContextOptions<MessagesDbContext> options)
        : base(options)
    {
        dbPath = Path.Join(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "messages.db");
    }

    public DbSet<SimpleChatItem> Messages { get; set; }

    public async Task InitializeDatabaseAsync()
    {
        await this.Database.EnsureCreatedAsync().ConfigureAwait(false);
    }

    // create a Sqlite database file in the local app data folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={dbPath}");
}