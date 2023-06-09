

using System.Diagnostics;

namespace CustomReportViewer.Controls;

[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class ReportViewer : ContentView
{
    public ReportViewer()
    {
        InitializeComponent();
    }

    #region Public properties

    /// <summary>
    /// Name of the report to be displayed.
    /// Example: 
    /// </summary>
    public string ReportName
    {
        get => (string)GetValue(ReportNameProperty);
        set => SetValue(ReportNameProperty, value);
    }
    
    /// <summary>
    /// REQUIRED - Sets the ServiceUrl of the ReportViewer.
    /// Example: 'https://mysite.com/api/reports'
    /// </summary>
    public string ServiceUrl
    {
        get => (string)GetValue(ServiceUrlProperty);
        set => SetValue(ServiceUrlProperty, value);
    }

    /// <summary>
    /// Override the default path for the viewer's resources URL
    /// Example: '~/api/reports/resources/js/telerikReportViewer'
    /// </summary>
    public string ViewerResourcesUrl
    {
        get => (string)GetValue(ViewerResourcesUrlProperty);
        set => SetValue(ViewerResourcesUrlProperty, value);
    }

    /// <summary>
    /// Override the default version of the Kendo CSS
    /// Example: "2022.2.802"
    /// </summary>
    public string KendoVersion
    {
        get => (string)GetValue(KendoVersionProperty);
        set => SetValue(KendoVersionProperty, value);
    }

    /// <summary>
    /// Overrides the version of jQuery.
    /// Example: "3.1.5"
    /// </summary>
    public string JqueryVersion
    {
        get => (string)GetValue(JqueryVersionProperty);
        set => SetValue(JqueryVersionProperty, value);
    }

    #endregion

    #region DependencyProperties

    public static BindableProperty ReportNameProperty = BindableProperty.Create(
        nameof(ReportName),
        typeof(string),
        typeof(ReportViewer),
        string.Empty,
        propertyChanged: OnReportNameChanged);
    
    public static BindableProperty ServiceUrlProperty = BindableProperty.Create(
        nameof(ServiceUrl),
        typeof(string),
        typeof(ReportViewer),
        null);

    public static BindableProperty ViewerResourcesUrlProperty = BindableProperty.Create(
        nameof(ViewerResourcesUrl),
        typeof(string),
        typeof(ReportViewer),
        "~/api/reports/resources/js/telerikReportViewer");

    public static BindableProperty KendoVersionProperty = BindableProperty.Create(
        nameof(KendoVersion),
        typeof(string),
        typeof(ReportViewer),
        "2022.2.802");

    public static BindableProperty JqueryVersionProperty = BindableProperty.Create(
        nameof(JqueryVersion),
        typeof(string),
        typeof(ReportViewer),
        "3.5.1");
    
    #endregion

    #region Methods
    
    private static void OnReportNameChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is ReportViewer self)
            self.LoadReport();
    }

    public void LoadReport()
    {
        if (string.IsNullOrEmpty(ServiceUrl))
        {
            throw new ArgumentNullException(nameof(ServiceUrl),"You must set the ServiceUrl property of the ReportViewer. For example, 'https://mysite.com/api/reports'.");
        }

        ViewRoot.Source = CreateWebViewSource();
    }

    private HtmlWebViewSource CreateWebViewSource()
    {
        var source = new HtmlWebViewSource();

        // TODO To use this example in a real project, you should build a serializer for the HTMLReportViewer's properties instead of string interpolation.
        source.Html = $@"<!DOCTYPE html>
                            <html xmlns=""http://www.w3.org/1999/xhtml"">
                                <head>
                                    <title>Telerik MVC HTML5 Report Viewer</title>
                                    <meta http-equiv=""X-UA-Compatible"" content=""IE=edge"">
                                    <meta name=""viewport"" content=""width=device-width, initial-scale=1, maximum-scale=1"" />

                                    <script src=""https://code.jquery.com/jquery-3.5.1.min.js""></script>
                                    <link href=""https://kendo.cdn.telerik.com/2022.2.802/styles/kendo.common.min.css"" rel=""stylesheet"" />
                                    <link href=""https://kendo.cdn.telerik.com/2022.2.802/styles/kendo.blueopal.min.css"" rel=""stylesheet"" />
                                    <script src=""~/api/reports/resources/js/telerikReportViewer""></script>

                                    <style>
                                        #reportViewer1 {{
                                            position: absolute;
                                            left: 5px;
                                            right: 5px;
                                            top: 5px;
                                            bottom: 5px;
                                            font-family: 'segoe ui', 'ms sans serif';
                                            overflow: hidden;
                                        }}
                                    </style>
                                </head>

                                <body>
                                    <div id=""reportViewer1""></div>
                                    <script>
                                        $(""#reportViewer1"").telerik_ReportViewer({{
                                            serviceUrl: ""{ServiceUrl}"",
                                            reportSource: {{ 
                                                report: ""{ReportName}"",
                                                parameters: ""{{ 
                                                   ""CultureID"" : ""en""
                                                }}""
                                            }}
                                        }});
                                    </script>
                                </body>
                            </html>";

        return source;
    }

    #endregion

    private void ViewRoot_OnNavigated(object sender, WebNavigatedEventArgs e)
    {
        Debug.WriteLine($"Navigated: {e.Result}");
    }
}