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
    private string _reportEngineConnection;
    private UriReportSource _reportSource;

    public WindowsReportViewer(MauiReportViewer virtualView)
    {
        Debug.WriteLine("WindowsReportViewer is being constructed");
        this._virtualView = virtualView;
        this._reportEngineConnection = $"engine=RestService;uri={virtualView.RestServiceUrl}";
        this._reportSource = new UriReportSource { Uri = virtualView.ReportName };

        this._viewer = new Telerik.ReportViewer.WinUI.ReportViewer()
        {
            HorizontalAlignment = Microsoft.UI.Xaml.HorizontalAlignment.Stretch,
            VerticalAlignment = Microsoft.UI.Xaml.VerticalAlignment.Stretch,
            ReportEngineConnection = this._reportEngineConnection,
            ReportSource = this._reportSource
        };
        
        this.Children.Add(this._viewer);
    }

    public void UpdateRestServiceUrl(string connection)
    {
        var state = this._viewer.ReportViewerModel.GetState();
        Debug.WriteLine($"WindowsReportViewer UpdateRestServiceUrl called: {connection}, State: {state}");
        this._reportEngineConnection = $"engine=RestService;uri={connection}";


        this.UpdateReport();
    }

    public void UpdateReportName(string name)
    {
        var state = this._viewer.ReportViewerModel.GetState();
        Debug.WriteLine($"WindowsReportViewer UpdateReportName called: {name}, State: {state}");
        this._reportSource = new UriReportSource { Uri = name };
        this.UpdateReport();
    }

    private void UpdateReport()
    {
        this._viewer.ReportEngineConnection = _reportEngineConnection;
        this._viewer.ReportSource = _reportSource;
        this._viewer.RefreshReport();
    }
}