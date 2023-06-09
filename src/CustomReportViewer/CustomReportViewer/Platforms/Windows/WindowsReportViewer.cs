using System.Diagnostics;
using CustomReportViewer.Controls;
using Telerik.Reporting;

namespace CustomReportViewer.WinUI;

/// <summary>
/// This is an actual NATIVE ReportViewer for WinUI 3! Other platforms are using HTML5 ReportViewer
/// https://docs.telerik.com/reporting/embedding-reports/display-reports-in-applications/how-to-set-reportsource-for-report-viewers#winui-report-viewer
/// </summary>
public class WindowsReportViewer : Microsoft.UI.Xaml.Controls.Grid
{
    private MauiReportViewer _virtualView;
    private Telerik.ReportViewer.WinUI.ReportViewer _viewer;

    public WindowsReportViewer(MauiReportViewer virtualView)
    {
        Debug.WriteLine("WindowsReportViewer is being constructed");
        this._virtualView = virtualView;

        this._viewer = new Telerik.ReportViewer.WinUI.ReportViewer()
        {
            HorizontalAlignment = Microsoft.UI.Xaml.HorizontalAlignment.Stretch,
            VerticalAlignment = Microsoft.UI.Xaml.VerticalAlignment.Stretch
        };

        this.Children.Add(this._viewer);

        this._viewer.ReportEngineConnection = $"engine=RestService;uri={virtualView.RestServiceUrl}";
        this._viewer.ReportSource = new UriReportSource { Uri = virtualView.ReportName };
        
        this._viewer.RefreshReport();
    }

    public void UpdateRestServiceUrl(string connection)
    {
        Debug.WriteLine($"WindowsReportViewer UpdateRestServiceUrl called: {connection}");
        this._viewer.ReportEngineConnection = $"engine=RestService;uri={connection}";
        this._viewer.RefreshReport();
    }

    public void UpdateReportName(string name)
    {
        Debug.WriteLine($"WindowsReportViewer UpdateReportName called: {name}");
        this._viewer.ReportSource = new UriReportSource { Uri = name };
        this._viewer.RefreshReport();
    }
}