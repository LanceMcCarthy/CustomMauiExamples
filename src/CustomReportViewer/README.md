## ReportViewer

This demo has a custom ReportViewer for .NET MAUI. That control's platform handler does two things:

- On Windows, it uses the native winUI 3 ReportViewer throught he MAUI handler. This is a pure native Windows implementation.
- On iOS, MacCatalyst, and Android: The HTML5 ReportViewer is used in a WebView thorugh BindableProperties to render reports.

```xaml
<controls:MauiReportViewer 
    RestServiceUrl="https://webapifortelerikdemos.azurewebsites.net/api/reports"
    ReportName="Barcodes Report.trdp"/>
```

### Runtime - Windows

![Windows ReportViewer](https://github.com/LanceMcCarthy/CustomMauiExamples/assets/3520532/9ff626b6-f7e2-4063-84c3-792d9572f218)

For more information, see the code in the `Handlers` folder.

### iOS and Android

There is currently a problem with the native WebViews from loading dynamic javascript content. All the code is there for ti to work, but the webview are not yet cooperating.