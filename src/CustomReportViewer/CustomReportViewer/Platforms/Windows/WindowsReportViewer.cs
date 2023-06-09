using CustomReportViewer.Controls;
using Telerik.Reporting;

namespace CustomReportViewer.WinUI;

/// <summary>
/// This is an actual NATIVE ReportViewer for WinUI 3! Other platforms are using HTML5 ReportViewer
/// </summary>
public class WindowsReportViewer : Telerik.ReportViewer.WinUI.ReportViewer
{
    private MauiReportViewer _virtualView;

    public WindowsReportViewer(MauiReportViewer virtualView)
    {
        this._virtualView = virtualView;
        this.ReportEngineConnection = $"engine=RestService;uri={virtualView.RestServiceUrl}";
        this.ReportSource = new UriReportSource { Uri = virtualView.ReportName };
        this.RefreshReport();
    }

    public void UpdateRestServiceUrl(string connection)
    {
        this.ReportEngineConnection = $"engine=RestService;uri={connection}";
        this.RefreshReport();
    }

    public void UpdateReportName(string uri)
    {
        this.ReportSource = new UriReportSource { Uri = uri };
        this.RefreshReport();
    }
}