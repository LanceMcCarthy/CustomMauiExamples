#if IOS
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomReportViewer.Controls;
using Microsoft.Maui.Handlers;

namespace CustomReportViewer.Handlers
{
    public partial class MauiReportViewerHandler : ViewHandler<MauiReportViewer, IosReportViewer>
    {
        protected override IosReportViewer CreatePlatformView() => new(VirtualView);

        protected override void ConnectHandler(IosReportViewer platformView)
        {
            base.ConnectHandler(platformView);

            // Perform any control setup here
        }

        protected override void DisconnectHandler(IosReportViewer platformView)
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
