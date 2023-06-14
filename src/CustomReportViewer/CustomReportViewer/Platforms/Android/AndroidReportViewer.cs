using Android.Content;
using CustomReportViewer.Controls;
using WebView = Android.Webkit.WebView;

namespace CustomReportViewer;

public sealed partial class AndroidReportViewer : WebView
{
    public string BaseUrl = "file:///android_asset/";
    private Context _context;
    private MauiReportViewer _virtualView;

    public AndroidReportViewer(Context context, MauiReportViewer virtualView) : base(context)
    {
        _context = context;
        _virtualView = virtualView ?? throw new ArgumentNullException("handler was null");
        
    }

    public void UpdateRestServiceUrl(string connection) => this._virtualView.RestServiceUrl = connection;

    public void UpdateReportName(string reportName) => this._virtualView.ReportName = reportName;

    public void LoadReportViewer()
    {
        System.Diagnostics.Debug.WriteLine($"--- LoadReportViewer Started: ({_virtualView.ReportName} on {_virtualView.RestServiceUrl}).");

        var htmlString = $@"<!DOCTYPE html>
                            <html xmlns=""http://www.w3.org/1999/xhtml"">
                                <head>
                                    <title>Telerik HTML5 Report Viewer</title>
                                    <meta http-equiv=""X-UA-Compatible"" content=""IE=edge"">
                                    <meta name=""viewport"" content=""width=device-width, initial-scale=1, maximum-scale=1"" />

                                    <script src=""https://code.jquery.com/jquery-3.5.1.min.js"" type=""application/javascript""></script>
                                    <link href=""https://kendo.cdn.telerik.com/2022.2.802/styles/kendo.common.min.css"" rel=""stylesheet"" />
                                    <link href=""https://kendo.cdn.telerik.com/2022.2.802/styles/kendo.blueopal.min.css"" rel=""stylesheet"" />
                                    <script src=""~/api/reports/resources/js/telerikReportViewer"" type=""application/javascript""></script>

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
                                            serviceUrl: ""{_virtualView.RestServiceUrl}"",
                                            reportSource: {{ 
                                                report: ""{_virtualView.ReportName}"",
                                                parameters: ""{{ 
                                                   ""CultureID"" : ""en""
                                                }}""
                                            }}
                                        }});
                                    </script>
                                </body>
                            </html>
        ";
        
        this.LoadDataWithBaseURL(BaseUrl, htmlString, "text/html", "UTF-8", null);

        //this.LoadData(htmlString, "text/html", "UTF-8");

        System.Diagnostics.Debug.WriteLine($"--- LoadReportViewer Completed: ({_virtualView.ReportName} on {_virtualView.RestServiceUrl}).");
    }
}