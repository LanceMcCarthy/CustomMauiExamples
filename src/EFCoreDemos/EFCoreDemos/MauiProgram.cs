using EFCoreDemos.Models;
using EFCoreDemos.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Telerik.Maui.Controls.Compatibility;

namespace EFCoreDemos
{
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

            // OPTION 1 - Local DB
            // We are using SQLite for simplicity
            builder.Services.AddDbContext<StudentDbContext>(options => options.UseSqlite());

            // OPTION 2 - SQL Server
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
}
