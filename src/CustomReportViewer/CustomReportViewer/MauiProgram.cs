using CustomReportViewer.Controls;
using CustomReportViewer.Handlers;
using Microsoft.Extensions.Logging;

namespace CustomReportViewer;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UseTelerikReporting() // register handlers
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			})
            .ConfigureMauiHandlers(handlers =>
            {
                handlers.AddHandler(typeof(MauiReportViewer), typeof(MauiReportViewerHandler));
            });

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
