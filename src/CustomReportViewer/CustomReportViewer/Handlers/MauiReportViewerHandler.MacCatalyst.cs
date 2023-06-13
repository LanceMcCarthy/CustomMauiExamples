#if MACCATALYST
using CustomReportViewer.Controls;
using Microsoft.Maui.Handlers;

namespace CustomReportViewer.Handlers
{
    public partial class MauiReportViewerHandler : ViewHandler<MauiReportViewer, MacReportViewer>
    {
        protected override MacReportViewer CreatePlatformView() => new(VirtualView);

        protected override void ConnectHandler(MacReportViewer platformView)
        {
            base.ConnectHandler(platformView);

            // initial setup
        }

        protected override void DisconnectHandler(MacReportViewer platformView)
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
