using Telerik.Maui.Controls.Compatibility;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace CaptchaControl.Maui
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseTelerik()
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("Agbalumo-Regular.ttf", "Agbalumo");
                    fonts.AddFont("LibreBaskerville-Regular.ttf", "Libre Baskerville");
                    fonts.AddFont("DancingScript-Regular.ttf", "Dancing Script");
                });

            return builder.Build();
        }
    }
}