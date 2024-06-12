using EFCoreDemos.Models;
using EFCoreDemos.ViewModels;
using EFCoreDemos.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Telerik.Maui.Controls.Compatibility;

namespace EFCoreDemos;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseTelerik()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        // Option 1 - I am using Sqlite for this demo because it is convenient and fast
        builder.Services.AddDbContext<StudentDbContext>(options => options.UseSqlite());

        // OPTION 2 - SQL Server
        // If you were using SQL server, you would set up the DB context like this
        // builder.Services.AddDbContext<StudentDbContext>(options => options.UseSqlServer("YOUR_SQL_SERVER_CONNECTION_STRING"));

        builder.Services.AddTransient<MainPageViewModel>();
        builder.Services.AddTransient<SortingPageViewModel>();
        builder.Services.AddTransient<FilteringPageViewModel>();

        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<SortingPage>();
        builder.Services.AddTransient<FilteringPage>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}