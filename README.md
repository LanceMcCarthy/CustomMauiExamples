# Custom Maui Examples

This is an evolution of my frequently-referenced [Custom Xamarin Demos repo](https://github.com/LanceMcCarthy/CustomXamarinDemos), but strictly for .NET MAUI applications. This is where you will find helpful implementations of edge-case scenarios that fall outside the [scope of support](https://www.telerik.com/account/support-center/scope).

| Demo Description | Code | 
|------|---|
| [Custom Chart Legend](#custom-chart-legend) | [src/ScatterWithLegend/](src/ScatterWithLegend/) |
| [Printing Demo](#printing) | [src/DocumentPrinting/](src/DocumentPrinting/) |
| [MAUI ReportViewer Demo](#reportviewer) | [src/CustomReportViewer/](src/CustomReportViewer/) |
| [Multi-Window TabView](#multi-window-tabview) | [src/MultiWindowDemo/](src/MultiWindowDemo/) |
| [DependencyInjection with TabView](#TabViewItems-with-dependency-injection) | [src/DepndInjtnDemo](src/DepndInjtnDemo) |
| [gRPC Demo](#grpc-demo) | [src/RealtimeDataSystem](src/RealtimeDataSystem) |
| [Custom Controls](#lantz-controls) | [src/LantzControls](src/LantzControls) |
| [FlyoutPage Navigation](#flyoutpage-navigation) | [src/FlyoutExample](src/FlyoutExample) |
| [Blazor Hybrid With Telerik XAML](#blazor-hybrid-with-telerik-xaml) | [src/BlazorHybridWithTelerikXaml](src/BlazorHybridWithTelerikXaml) |

## Custom Chart Legend

If you would like more control over the appearance of your chart legend, create a completely custom legend with minimal effort using a RadItemsControl and the chart's Loaded event. This demo shows you exactly how it's done, visit MainPage to see the code.

![custom chart legend](https://github.com/LanceMcCarthy/CustomMauiExamples/assets/3520532/9f27470c-40a8-4b4c-a549-d90b4c158886)

## Printing

In order to print in .NET MAUI, you must use the native platform APIs. On Windows, this also includes manually preparing the print preview. This example shows you how to print a PDF file on Windows, iOS, MacCatalyst, and Android.

The code is in the `Helpers` folder, with each platform having its's own class file. Here's the result when starting a print on Windows.

![printing](https://github.com/LanceMcCarthy/CustomMauiExamples/assets/3520532/8801026d-69c9-4a9d-b2bd-bd34ff6f8fdc)

> This is very document specific, you will need to do different work for different document types as this demo project is simply a place for you to get started.

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

## Multi-Window TabView

A custom project that demonstrates "tear-able tabs" with [RadTabView](https://docs.telerik.com/devtools/maui/controls/tabview/overview) and .NET MAUI's [multi-window features](https://learn.microsoft.com/en-us/dotnet/maui/fundamentals/windows). 

### Before

![before](https://github.com/LanceMcCarthy/CustomMauiExamples/assets/3520532/5f9481a6-599d-44a8-bce4-ad0b4c3c84da)

### After

![after](https://github.com/LanceMcCarthy/CustomMauiExamples/assets/3520532/3f51435f-50d4-4767-98d4-a14c20ad6016)

> The buttons in the tab headers also let you move tabs left or right.

## TabViewItems with Dependency Injection

This demo shows you how you can leverage .NET MAUI's built-in Dependency Injection to achieve IoC with your views and view models.

![image](https://user-images.githubusercontent.com/3520532/201428243-95840722-f319-4676-9210-14b4c61bcfd2.png)

## gRPC Demo

This example comes with both the server and client projects. It uses a DataGrid to show results form real-time stock trades. Find the Visual Studio solution in the `src\RealtimeDataSystem` folder.

Please refer to [Microsoft gRPC documentation](https://docs.microsoft.com/en-us/aspnet/core/tutorials/grpc/grpc-start?view=aspnetcore-6.0&tabs=visual-studio) for more information about gRPC in a .NET application.

## Lantz Controls

This is project that has various custom controls and will evolve over time as I add more. Currently, there is only a `FloatingLabel` control.

#### FloatingLabel

Unfocused with RadEntry

![unfocused](https://user-images.githubusercontent.com/3520532/185198526-85ca9f1f-3f49-4db2-9fe4-0bd3d18bac3e.png)

Focused with RadEntry

![focused empty](https://user-images.githubusercontent.com/3520532/185198745-6760b46f-97aa-4f7f-98c3-99330f6325a5.png)

Focused with RadEntry and Text Content

![focused filled](https://user-images.githubusercontent.com/3520532/185198803-baaa19cc-ac66-4a21-9b5b-c85936d1e7e4.png)

## FlyoutPage Navigation

This demo shows you how you can use **FlyoutPage** to navigate around an application. It shows you both top level and drill-down details page navigation without using **Shell**.

On initial launch, the FlyoutPage's `Detail` property is set to an instance of a ContentPage for authentication.

![Initial Launch](https://user-images.githubusercontent.com/3520532/169628274-6bce881c-4e13-4378-9cdc-903a6aeae0af.png)

After signing in, the `Detail` of the **FlyoutPage** is replaced with a **NavigationPage**. The lets the user navigate around the app using the menu on the left.

- That menu is actually a ContentPage hosted by the `FlyputPage.Flyout` property.
- The area on the right is a "RoutesPage" **ContentPage** hosted in a **NavigationPage** which is set to the `FlyoutPage.Detail`

![Routes Page](https://user-images.githubusercontent.com/3520532/169628294-5e84f097-af78-4f50-8540-7dc5d483aff0.png)

Finally, because the `FlyoutPage.Detail` is a **NavigationPage**, we can 'drill-down' navigate from the RoutesPage to a "RouteDetailPage" while still technically being on the Routes page that was selected in the menu.

![Route Details Page](https://user-images.githubusercontent.com/3520532/169628313-e22e63f2-b662-4138-ab92-71b9b1f88ab1.png)

## Blazor Hybrid With Telerik XAML

This demo shows you how you can access the XAML part of a .NET MAUI Blazor Hybrid application. It uses a simple RadPopup, but the concept applies to anything else you might want to do on top of the BlazorWebView.


