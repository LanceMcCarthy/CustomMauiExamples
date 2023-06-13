namespace CustomReportViewer.Controls;

public class MauiReportViewer : View
{
    public MauiReportViewer() { }

    public static readonly BindableProperty RestServiceUrlProperty =
        BindableProperty.Create(nameof(RestServiceUrl), typeof(string), typeof(MauiReportViewer), null);

    public static readonly BindableProperty ReportNameProperty =
        BindableProperty.Create(nameof(ReportName), typeof(string), typeof(MauiReportViewer), null);            
    
    public string RestServiceUrl
    {
        get => (string)GetValue(RestServiceUrlProperty);
        set => SetValue(RestServiceUrlProperty, value);
    }

    public string ReportName
    {
        get => (string)GetValue(ReportNameProperty);
        set => SetValue(ReportNameProperty, value);
    }
}