#if ANDROID
using Microsoft.Maui.Handlers;
using CustomReportViewer.Controls;

namespace CustomReportViewer.Handlers
{
    public partial class MauiReportViewerHandler: ViewHandler<MauiReportViewer, AndroidReportViewer>
    {
        protected override AndroidReportViewer CreatePlatformView() => new(Context, VirtualView);

        protected override void ConnectHandler(AndroidReportViewer platformView)
        {
            base.ConnectHandler(platformView);

            // Perform any control setup here
        }

        protected override void DisconnectHandler(AndroidReportViewer platformView)
        {

            base.DisconnectHandler(platformView);
        }

        public static void MapRestServiceUrl(MauiReportViewerHandler handler, MauiReportViewer viewer)
        {
            handler.PlatformView?.UpdateRestServiceUrl(viewer.RestServiceUrl);
        }

        public static void MapReportName(MauiReportViewerHandler handler, MauiReportViewer viewer)
        {
            handler.PlatformView?.UpdateReportName(viewer.ReportName);
        }
    }
}
#endif