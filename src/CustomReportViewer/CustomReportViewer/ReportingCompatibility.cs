using CustomReportViewer.Controls;
using CustomReportViewer.Handlers;

namespace CustomReportViewer
{
    public static class ReportingCompatibility
    {
        public static MauiAppBuilder UseTelerikReporting(this MauiAppBuilder builder)
        {
            builder.ConfigureMauiHandlers(handlers =>
            {
                handlers.AddHandler(typeof(MauiReportViewer), typeof(MauiReportViewerHandler));
            });

            return builder;
        }
    }
}
