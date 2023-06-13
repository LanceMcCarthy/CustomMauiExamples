#if IOS16_0_OR_GREATER
using CustomReportViewer.Controls;
using Foundation;
using UIKit;
using WebKit;

namespace CustomReportViewer;

public class IosReportViewer : UIView
{
    private MauiReportViewer _virtualView;
    private WKWebView _webView;
    
    public IosReportViewer(MauiReportViewer virtualView)
    {
        _virtualView = virtualView;

        var viewController = WindowStateManager.Default.GetCurrentUIViewController();

        _webView = new WKWebView(viewController.View.Frame, new WKWebViewConfiguration());
        viewController.View.AddSubview(_webView);

        var htmlString = $@"<!DOCTYPE html>
                            <html xmlns=""http://www.w3.org/1999/xhtml"">
                                <head>
                                    <title>Telerik HTML5 Report Viewer</title>
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

        _webView.LoadData(
            new NSData(htmlString,NSDataBase64DecodingOptions.None), 
            "text/html",
            "UTF-8", 
            new NSUrl(""));
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

        _webView.LoadData(
            new NSData(htmlString,NSDataBase64DecodingOptions.None), 
            "text/html",
            "UTF-8", 
            new NSUrl(""));
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

        _webView.LoadData(
            new NSData(htmlString,NSDataBase64DecodingOptions.None), 
            "text/html",
            "UTF-8", 
            new NSUrl(""));
    }
}

#endif