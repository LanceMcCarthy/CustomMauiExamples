using Microsoft.Extensions.Logging;
using ChatDataSources.Maui.Models;
using ChatDataSources.Maui.ViewModels;
using Microsoft.EntityFrameworkCore;
using Telerik.Maui.Controls.Compatibility;

namespace ChatDataSources.Maui;

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

        // We are using SQLite for simplicity
        builder.Services.AddDbContext<MessagesDbContext>(options => options.UseSqlite());

        // If you were using SQL server, you would set up the DB context like this
        // builder.Services.AddDbContext<MessagesDbContext>(options => options.UseSqlServer("SQL_SERVER_CONNECTION_STR"));


        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<MainViewModel>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}