using Microsoft.Maui.LifecycleEvents;
using Telerik.Maui.Controls.Compatibility;

#if WINDOWS10_0_17763_0_OR_GREATER
using FlyoutExample.Platforms.Windows;
using WinUIEx;

#elif MACCATALYST
using AppKit;
using CoreGraphics;
using Foundation;
using UIKit;

#elif IOS
#elif ANDROID
#elif TIZEN
// nothing special here, yet
#endif

namespace FlyoutExample;

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
                fonts.AddFont("telerikfontexamples.ttf", "telerikfontexamples");
            });

        builder.ConfigureLifecycleEvents(events =>
        {
#if WINDOWS10_0_17763_0_OR_GREATER

            events.AddWindows(wndLifeCycleBuilder =>
            {
                wndLifeCycleBuilder.OnWindowCreated(window =>
                {
                    const int width = 1200;
                    const int height = 800;
                    const int x = 1920 / 2 - width / 2;
                    const int y = 1080 / 2 - height / 2;
                    
                    // Microsoft.Xaml.UI.Window Extensions
                    window.MoveAndResize(x, y, width, height);
                    window.TryMicaOrAcrylic();
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

        return builder.Build();
	}
}
