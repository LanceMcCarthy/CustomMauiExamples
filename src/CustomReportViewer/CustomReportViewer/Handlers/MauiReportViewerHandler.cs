using CustomReportViewer.Controls;
using Microsoft.Maui.Handlers;

namespace CustomReportViewer.Handlers
{
    public partial class MauiReportViewerHandler
    {
        public static IPropertyMapper<MauiReportViewer, MauiReportViewerHandler> PropertyMapper = new PropertyMapper<MauiReportViewer, MauiReportViewerHandler>(ViewHandler.ViewMapper)
        {
            [nameof(MauiReportViewer.RestServiceUrl)] = MapRestServiceUrl,
            [nameof(MauiReportViewer.ReportName)] = MapReportName
        };

        public MauiReportViewerHandler() : base(PropertyMapper)
        {
        }
    }
}