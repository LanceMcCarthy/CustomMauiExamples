using CustomReportViewer.Controls;
using CustomReportViewer.Handlers;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.LifecycleEvents;

#if WINDOWS
using WinUIEx;

#elif MACCATALYST
using CoreGraphics;
using UIKit;

#elif IOS
#elif ANDROID
#elif TIZEN

#endif

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

        // Needs using Microsoft.Maui.LifecycleEvents for this extension method
        builder.ConfigureLifecycleEvents(events =>
        {
#if WINDOWS
            events.AddWindows(wndLifeCycleBuilder =>
            {
                wndLifeCycleBuilder.OnWindowCreated(window =>
                {
                    window.CenterOnScreen(1024,768); //uses WinUIEx

                    var manager = WinUIEx.WindowManager.Get(window);
                    manager.PersistenceId = "MainWindowPersistanceId";
                    manager.MinWidth = 640;
                    manager.MinHeight = 480;
                });
            });

#elif MACCATALYST

                // Using CoreGraphics and UIKit
                events.AddiOS(wndLifeCycleBuilder =>
                {
                    wndLifeCycleBuilder.SceneWillConnect((scene, session, options) =>
                    {
                        if (scene is UIWindowScene { SizeRestrictions: { } } windowScene)
                        {
                            windowScene.SizeRestrictions.MaximumSize = new CGSize(1200, 900);
                            windowScene.SizeRestrictions.MinimumSize = new CGSize(600, 400);
                        }
                    });

                });
#endif
        });

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
