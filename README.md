# Custom Maui Examples

This is an evolution of my frequently referenced Custom Xamarin Demos repository. This is where you will find helpful implementations of edge-case scenarios that fall outside the scope of commercial support.

| Demo Description | Code | 
|------|------|
| [DependencyInjection with TabView](#TabViewItems-with-dependency-injection) | [src/DepndInjtnDemo](src/DepndInjtnDemo) |
| [gRPC Demo](#grpc-demo) | [src/RealtimeDataSystem](src/RealtimeDataSystem) |
| [Custom Controls](#lantz-controls) | [src/LantzControls](src/LantzControls) |
| [FlyoutPage Navigation](#flyoutpage-navigation) | [src/FlyoutExample](src/FlyoutExample) |
| [Blazor Hybrid With Telerik XAML](#blazor-hybrid-with-telerik-xaml) | [src/BlazorHybridWithTelerikXaml](src/BlazorHybridWithTelerikXaml) |

## TabViewItems with Dependency Injection

this demo shows you how you can levergare .NET MAUI's amazing built-in Dependency Injection to acive e IoC with your views and view models.

![image](https://user-images.githubusercontent.com/3520532/201428243-95840722-f319-4676-9210-14b4c61bcfd2.png)

## gRPC Demo

This example comes with both the server and client projects. It uses a DataGrid to show results form real-time stock trades. Find the Visual Studio solution in the `src\RealtimeDataSystem` folder.

Please refer to [Microsoft gRPC documentation](https://docs.microsoft.com/en-us/aspnet/core/tutorials/grpc/grpc-start?view=aspnetcore-6.0&tabs=visual-studio) for more information about gRPC in a .NET application.

## Lantz Controls

This is project that has various different custom controls and will evolve over time as I add more. Currently, there is only a `FloatingLabel` control.

#### FloatingLabel

Unfocused with RadEntry

![unfocused](https://user-images.githubusercontent.com/3520532/185198526-85ca9f1f-3f49-4db2-9fe4-0bd3d18bac3e.png)

Focused with RadEntry

![focused empty](https://user-images.githubusercontent.com/3520532/185198745-6760b46f-97aa-4f7f-98c3-99330f6325a5.png)

Focused with RadEntry and Text Content

![focused filled](https://user-images.githubusercontent.com/3520532/185198803-baaa19cc-ac66-4a21-9b5b-c85936d1e7e4.png)

## FlyoutPage Navigation

This demo shows you how you can use **FlyoutPage** to navigate around an application. It shows you both top level and drill-down details page navigation without the use of **Shell**.

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


