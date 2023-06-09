#nullable enable
#if WINDOWS
using System.Diagnostics;
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

            Debug.WriteLine("MauiReportViewerHandler ConnectHandler called");
        }
        
        protected override void DisconnectHandler(WindowsReportViewer platformView)
        {
            base.DisconnectHandler(platformView);

            Debug.WriteLine("MauiReportViewerHandler DisconnectHandler called");
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