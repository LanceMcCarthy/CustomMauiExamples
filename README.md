# Custom Maui Examples

This is an evolution of my frequently-referenced [Custom Xamarin Demos repo](https://github.com/LanceMcCarthy/CustomXamarinDemos), but strictly for .NET MAUI applications. This is where you will find helpful implementations of edge-case scenarios that fall outside the [scope of support](https://www.telerik.com/account/support-center/scope).

| Demo | Code |
|------|------|
| [Signature Vectorizer](#signature-vectorizer) | [src/SignatureVectorizer/](src/SignatureVectorizer) |
| [DataGrid - EFCore Demos and LoadOnDemand](#efcore-demos) | [src/EFCoreDemos/](src/EFCoreDemos) |
| [Chat - Advanced Data Sources](#chat-with-advanced-data-sources) | [src/ChatDataSources/](src/ChatDataSources/) |
| [TabView Header Notification Badge](#signature-editor) | [src/TabHeaderNotification/](src/TabHeaderNotification/) |
| [Captcha Control](#captcha-control) | [src/CaptchaControl/](src/CaptchaControl/) |
| [Popup Service](#popup-service) | [src/PopupServiceDemo/](src/PopupServiceDemo/) |
| [Signature Editor](#signature-editor) | [src/SignatureEditor/](src/SignatureEditor/) |
| [Custom Chart Legend](#custom-chart-legend) | [src/ScatterWithLegend/](src/ScatterWithLegend/) |
| [Printing Demo](#printing) | [src/DocumentPrinting/](src/DocumentPrinting/) |
| [MAUI ReportViewer Demo](#reportviewer) | [src/CustomReportViewer/](src/CustomReportViewer/) |
| [Multi-Window TabView](#multi-window-tabview) | [src/MultiWindowDemo/](src/MultiWindowDemo/) |
| [DependencyInjection with TabView](#TabViewItems-with-dependency-injection) | [src/DepndInjtnDemo](src/DepndInjtnDemo) |
| [gRPC Demo](#grpc-demo) | [src/RealtimeDataSystem](src/RealtimeDataSystem) |
| [Custom Controls](#lantz-controls) (`ColumnChooser`, `LabeledCheckBox`, `FloatingLabel`, `PartialRating`, `SegmentView`) | [src/LantzControls](src/LantzControls) |
| [FlyoutPage Navigation](#flyoutpage-navigation) | [src/FlyoutExample](src/FlyoutExample) |
| [Blazor Hybrid With Telerik XAML](#blazor-hybrid-with-telerik-xaml) | [src/BlazorHybridWithTelerikXaml](src/BlazorHybridWithTelerikXaml) |

## Signature Vectorizer

You can extract the SVG point data from  SignaturePad's signature:



Or directly from a loaded png file:



## EFCore Demos

This project contains DataGrid with automatic load on demand, fetching data from a database using EntityFrameworkCore.

![datagrid and efcore](https://github.com/LanceMcCarthy/CustomMauiExamples/assets/3520532/1843f508-6fdb-48de-8b1f-657f0465d051)

## Chat with Advanced Data Sources

This demo contains a RadChat, directly connected to an entityFramework DBcontext.

![chat](https://github.com/LanceMcCarthy/CustomMauiExamples/assets/3520532/6e1bbc02-96a2-42ea-b1f5-d2f5ffc05b3c)

> Future plans are to also include SignalR and gRPC service sources.

## TabView Header Notification Badge

This demo uses conditional logic, with a custom HeaderItem `ControlTemplate` to only show notification badges on specific tab headers. This is accomplished by combining information from both the `TabViewHeaderItem` context and the `Label.Text` value to determine if the Label should be visible for that specific tab.

![image](https://github.com/LanceMcCarthy/CustomMauiExamples/assets/3520532/767b61fe-26c6-4f24-ad8e-c93947d04296)

## Captcha Control

Create a custom CAPTCHA control using using multiple fonts and colors using .NET MAUI's `CanvasView` to render different random characters with AttributedText and the `DrawText` method. 

![captcha](https://github.com/LanceMcCarthy/CustomMauiExamples/assets/3520532/2ff1f558-199f-49d6-8991-0748680a59a5)

Visit [Microsoft's 'draw attributed text' documentation example](https://learn.microsoft.com/en-us/dotnet/maui/user-interface/graphics/draw#draw-attributed-text) to learn more.

## Popup Service

This example uses .NET MAUI's new DependencyInjection system to register a popup service that can be used anywhere in the app. [Please visit the README](src/PopupServiceDemo/) for information on how it works.

As a sneak peek, here is the service being used in a view model.

```csharp
public class HomeViewModel
{
    private readonly PopupService popupService;

    public HomeViewModel(PopupService service)
    {
        this.popupService = service;
        
        OpenPopupCommand = new Command(OpenPopup);
    }

    public Command OpenPopupCommand { get; set; }

    private void OpenPopup()
    {
        var popupContent = CreatePopupContent();
        
        // ***** Open the popup ***** //
        popupService.OpenPopup(popupContent);
    }
    ...
}
```

## Signature Editor

This demo shows how to dynamically load signatures and swap between **edit-mode** with the `RadSignaturePad`, and **view-mode** with the Image of the saved signature.

![signature editor](https://github.com/LanceMcCarthy/CustomMauiExamples/assets/3520532/eb0a0a6e-4007-4114-babf-f870cb8e025b)

> When the app launches, it first checks to see if a signature was already saved. If there was a previous signature, it will load that and start in view-mode. Otherwise, it will start in edit-mode.

## Custom Chart Legend

If you would like more control over the appearance of your chart legend, create a completely custom legend with minimal effort using a RadItemsControl and the chart's Loaded event. This demo shows you exactly how it's done, visit MainPage to see the code ([Jump to code](src/ScatterWithLegend/)).

![custom chart legend](/images/custom-series-legend.gif)

## Printing

In order to print in .NET MAUI, you must use the native platform APIs. On Windows, this also includes manually preparing the print preview. This example shows you how to print a PDF file on Windows, iOS, MacCatalyst, and Android ([Jump to code](src/DocumentPrinting/)).

The code is in the `Helpers` folder, with each platform having its's own class file. Here's the result when starting a print on Windows.

![printing](https://github.com/LanceMcCarthy/CustomMauiExamples/assets/3520532/8801026d-69c9-4a9d-b2bd-bd34ff6f8fdc)

> This is very document specific, you will need to do different work for different document types as this demo project is simply a place for you to get started.

## ReportViewer

This demo has a custom ReportViewer for .NET MAUI ([Jump to code](src/CustomReportViewer/)). That control's platform handler does two things:

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

A custom project that demonstrates "tear-able tabs" with [RadTabView](https://docs.telerik.com/devtools/maui/controls/tabview/overview) and .NET MAUI's [multi-window features](https://learn.microsoft.com/en-us/dotnet/maui/fundamentals/windows). You can break off a tab from one window and it will be moved to the new window instance ([Jump to code](src/MultiWindowDemo/)).

### Before

![before](https://github.com/LanceMcCarthy/CustomMauiExamples/assets/3520532/5f9481a6-599d-44a8-bce4-ad0b4c3c84da)

### After

![after](https://github.com/LanceMcCarthy/CustomMauiExamples/assets/3520532/3f51435f-50d4-4767-98d4-a14c20ad6016)

> The buttons in the tab headers also let you move tabs left or right.

## TabViewItems with Dependency Injection

This demo shows you how you can leverage .NET MAUI's built-in Dependency Injection to achieve IoC with your views and view models ([Jump to code](src/DepndInjtnDemo/)).

![image](https://user-images.githubusercontent.com/3520532/201428243-95840722-f319-4676-9210-14b4c61bcfd2.png)

## gRPC Demo

This example comes with both the server and client projects. It uses a DataGrid to show results form real-time stock trades ([Jump to code](src/RealtimeDataSystem/)).

Please refer to [Microsoft gRPC documentation](https://docs.microsoft.com/en-us/aspnet/core/tutorials/grpc/grpc-start?view=aspnetcore-6.0&tabs=visual-studio) for more information about gRPC in a .NET application.

## Lantz Controls

This is project that has various custom controls and will evolve over time as I add more ([Jump to code](src/LantzControls/)).

-  `FloatingLabel`
-  `LabeledCheckBox`
-  `ColumnChooser`
-  `PartialRating`
-  `SegmentView`

### FloatingLabel

Unfocused with RadEntry

![unfocused](https://user-images.githubusercontent.com/3520532/185198526-85ca9f1f-3f49-4db2-9fe4-0bd3d18bac3e.png)

Focused with RadEntry

![focused empty](https://user-images.githubusercontent.com/3520532/185198745-6760b46f-97aa-4f7f-98c3-99330f6325a5.png)

Focused with RadEntry and Text Content

![focused filled](https://user-images.githubusercontent.com/3520532/185198803-baaa19cc-ac66-4a21-9b5b-c85936d1e7e4.png)

### ColumnChooser

Can be attached to any `RadDataGrid` to allow the app user to show/hide any column.

![image](https://github.com/LanceMcCarthy/CustomMauiExamples/assets/3520532/082bda3f-6828-4669-b0f6-43fbb5e75579)

```xaml
<Grid ColumnDefinitions="*, Auto">
    <telerik:RadDataGrid x:Name="MyDataGrid"
                         AutoGenerateColumns="False">
        <telerik:RadDataGrid.Columns>
            <telerik:DataGridTextColumn PropertyName="Name" HeaderText="Name" />
            <telerik:DataGridNumericalColumn PropertyName="Age" HeaderText="Age" />
            <telerik:DataGridDateColumn PropertyName="DateOfBirth" HeaderText="DOB" CellContentFormat="{}{0:MM/dd/yyyy}" />
        </telerik:RadDataGrid.Columns>
    </telerik:RadDataGrid>

    <!-- Associate with a DataGrid -->
    <dataGrid:ColumnChooser x:Name="Chooser"
                            AssociatedDataGrid="{x:Reference MyDataGrid}"
                            Margin="20"
                            Grid.Column="1" />
</Grid>
```

### PartialRating

A rating control that can render fractional values.

![PartialRating](https://github.com/LanceMcCarthy/CustomMauiExamples/assets/3520532/04d97e30-c3f7-4d2e-9a76-0197bcd9a8bc)

#### Source:

- [PartialRating.xaml](https://github.com/LanceMcCarthy/CustomMauiExamples/blob/main/src/LantzControls/Input/PartialRating.xaml)
- [PartialRating.xaml.cs](https://github.com/LanceMcCarthy/CustomMauiExamples/blob/main/src/LantzControls/Input/PartialRating.xaml.cs)

#### Example

```xaml
<input:PartialRating x:Name="RottenTomatoesRating"/>
```
```csharp
private void Button_OnClicked(object sender, EventArgs e)
{
    var rating = Random.Shared.Next(0,5) + Random.Shared.NextDouble();

    RottenTomatoesRating.SetRating(rating);
}
```

### SegmentView

![SegmentView](https://github.com/LanceMcCarthy/CustomMauiExamples/assets/3520532/f5fa1ed4-f22d-4193-8385-51faf7560ca8)

#### Source:

- [SegmentView.xaml](https://github.com/LanceMcCarthy/CustomMauiExamples/blob/main/src/LantzControls/Input/SegmentView.xaml)
- [SegmentView.xaml.cs](https://github.com/LanceMcCarthy/CustomMauiExamples/blob/main/src/LantzControls/Input/SegmentView.xaml.cs)

#### Example

```xaml
<input:SegmentView x:Name="MySegmentView"
                   SelectedSegmentTextColor="#036ecb"
                   SelectedSegmentBackgroundColor="#e0edf8"
                   BackgroundColor="White"
                   BorderColor="#e1e1e1"
                   CornerRadius="4"
                   FontSize="12"
                   HeightRequest="30"
                   Margin="5" />
```
```csharp
MySegmentView.ItemsSource = [
    new SegmentItem() { Text = "Breakfast", ImageSource = ImageSource.FromFile("breakfast.png") },
    new SegmentItem() { Text = "Lunch", ImageSource = ImageSource.FromFile("lunch.png") },
    new SegmentItem() { Text = "Dinner", ImageSource = ImageSource.FromFile("dinner.png") }
];
```

## FlyoutPage Navigation

This demo shows you how you can use **FlyoutPage** to navigate around an application ([Jump to code](src/FlyoutExample/)). It shows you both top level and drill-down details page navigation without using **Shell**.

On initial launch, the FlyoutPage's `Detail` property is set to an instance of a ContentPage for authentication.

![Initial Launch](https://user-images.githubusercontent.com/3520532/169628274-6bce881c-4e13-4378-9cdc-903a6aeae0af.png)

After signing in, the `Detail` of the **FlyoutPage** is replaced with a **NavigationPage**. The lets the user navigate around the app using the menu on the left.

- That menu is actually a ContentPage hosted by the `FlyputPage.Flyout` property.
- The area on the right is a "RoutesPage" **ContentPage** hosted in a **NavigationPage** which is set to the `FlyoutPage.Detail`

![Routes Page](https://user-images.githubusercontent.com/3520532/169628294-5e84f097-af78-4f50-8540-7dc5d483aff0.png)

Finally, because the `FlyoutPage.Detail` is a **NavigationPage**, we can 'drill-down' navigate from the RoutesPage to a "RouteDetailPage" while still technically being on the Routes page that was selected in the menu.

![Route Details Page](https://user-images.githubusercontent.com/3520532/169628313-e22e63f2-b662-4138-ab92-71b9b1f88ab1.png)

## Blazor Hybrid With Telerik XAML

This demo shows you how you can access the XAML part of a .NET MAUI Blazor Hybrid application ([Jump to code](src/BlazorHybridWithTelerikXaml/)). It uses a simple RadPopup, but the concept applies to anything else you might want to do on top of the BlazorWebView.


