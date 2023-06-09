#nullable enable
#if WINDOWS
using CustomReportViewer.Controls;
using CustomReportViewer.WinUI;
using Microsoft.Maui.Handlers;

namespace CustomReportViewer.Handlers
{
    public partial class MauiReportViewerHandler : ViewHandler<MauiReportViewer, WindowsReportViewer>
    {
        protected override WindowsReportViewer CreatePlatformView() => new(VirtualView);

        protected override void ConnectHandler(WindowsReportViewer platformView)
        {
            base.ConnectHandler(platformView);

            // initial setup
            platformView.ReportEngineConnection = VirtualView.RestServiceUrl;
            platformView.ReportSource = new Telerik.Reporting.UriReportSource { Uri = VirtualView.ReportName };
        }

        protected override void DisconnectHandler(WindowsReportViewer platformView)
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