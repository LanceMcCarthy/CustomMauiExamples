using Microsoft.Extensions.Logging;
using Telerik.Maui.Controls.Compatibility;
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

namespace MultiWindowDemo.Maui;

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

#if DEBUG
		builder.Logging.AddDebug();
#endif

        // Needs using Microsoft.Maui.LifecycleEvents for this extension method
        builder.ConfigureLifecycleEvents(events =>
        {
#if WINDOWS
            // using WinUIEx
            events.AddWindows(wndLifeCycleBuilder =>
            {
                wndLifeCycleBuilder.OnWindowCreated(window =>
                {
                    //uses WinUIEx to remember window position and size
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

		return builder.Build();
	}
}
