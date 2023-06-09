using Android.Content;
using Android.Views;
using AndroidX.CoordinatorLayout.Widget;
using CustomReportViewer.Controls;

namespace CustomReportViewer;

public sealed partial class AndroidReportViewer : CoordinatorLayout
{
    private Context _context;
    private MauiReportViewer _virtualView;
    private Android.Webkit.WebView _webView;

    public AndroidReportViewer(Context context, MauiReportViewer virtualView) : base(context)
    {
        _context = context;
        _virtualView = virtualView;

        _webView = new Android.Webkit.WebView(_context);

        var relativeLayout = new Android.Widget.RelativeLayout(_context)
        {
            LayoutParameters = new LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent)
            {
                Gravity = (int)GravityFlags.Fill,
            }
        };

        relativeLayout.AddView(_webView);

        this.AddView(relativeLayout);
        
        var htmlString = $@"<!DOCTYPE html>
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
                                            serviceUrl: ""{virtualView.RestServiceUrl}"",
                                            reportSource: {{ 
                                                report: ""{virtualView.ReportName}"",
                                                parameters: ""{{ 
                                                   ""CultureID"" : ""en""
                                                }}""
                                            }}
                                        }});
                                    </script>
                                </body>
                            </html>";

        _webView.LoadData(htmlString, "text/html", "UTF-8");
    }

    public void UpdateRestServiceUrl(string connection)
    {
        var htmlString = $@"<!DOCTYPE html>
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
                                            serviceUrl: ""{connection}"",
                                            reportSource: {{ 
                                                report: ""{_virtualView.ReportName}"",
                                                parameters: ""{{ 
                                                   ""CultureID"" : ""en""
                                                }}""
                                            }}
                                        }});
                                    </script>
                                </body>
                            </html>";

        _webView.LoadData(htmlString, "text/html", "UTF-8");
    }

    public void UpdateReportName(string reportName)
    {
        var htmlString = $@"<!DOCTYPE html>
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
                                            serviceUrl: ""{_virtualView.RestServiceUrl}"",
                                            reportSource: {{ 
                                                report: ""{reportName}"",
                                                parameters: ""{{ 
                                                   ""CultureID"" : ""en""
                                                }}""
                                            }}
                                        }});
                                    </script>
                                </body>
                            </html>";

        _webView.LoadData(htmlString, "text/html", "UTF-8");
    }
}