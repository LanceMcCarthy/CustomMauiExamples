using Microsoft.Extensions.Logging;
using Microsoft.Maui.LifecycleEvents;
using Telerik.Maui.Controls.Compatibility;

#if MACCATALYST
using CoreGraphics;
using UIKit;
#endif


namespace SignatureEditor;

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

        return builder.Build();
    }

    public static MauiAppBuilder RegisterLifecycleEvents(this MauiAppBuilder builder)
    {
        builder.ConfigureLifecycleEvents(events =>
        {
#if WINDOWS10_0_17763_0_OR_GREATER

            events.AddWindows(wndLifeCycleBuilder =>
            {
                wndLifeCycleBuilder.OnWindowCreated(window =>
                {
                    var manager = WinUIEx.WindowManager.Get(window);
                    manager.PersistenceId = "MainWindowPersistanceId";
                    manager.MinWidth = 480;
                    manager.MinHeight = 480;
                });
            });

#elif MACCATALYST
                
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

        return builder;
    }
}
