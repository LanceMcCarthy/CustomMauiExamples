# Custom Maui Examples

This is an evolution of my frequently referenced Custom Xamarin Demos repository. This is where you will find helpful implementations of edge-case scenarios that fall outside the scope of commercial support.

## gRPC Demo

This example comes with both the server and client projects. It uses a DataGrid to show results form real-time stock trades. Find the Visual Studio solution in the `src\RealtimeDataSystem` folder.

Please refer to [Microsoft gRPC documentation](https://docs.microsoft.com/en-us/aspnet/core/tutorials/grpc/grpc-start?view=aspnetcore-6.0&tabs=visual-studio) for more information about gRPC in a .NET application.

## FlyoutPage Navigation Demo

This demo shows you how you can use **FlyoutPage** to navigate around an application. It shows you both top level and drill-down details page navigation without the use of **Shell**.

On initial launch, the FlyoutPage's `Detail` property is set to an instance of a ContentPage for authentication.

![Initial Launch](https://user-images.githubusercontent.com/3520532/169628274-6bce881c-4e13-4378-9cdc-903a6aeae0af.png)

After signing in, the `Detail` of the **FlyoutPage** is replaced with a **NavigationPage**. The lets the user navigate around the app using the menu on the left.

- That menu is actually a ContentPage hosted by the `FlyputPage.Flyout` property.
- The area on the right is a "RoutesPage" **ContentPage** hosted in a **NavigationPage** which is set to the `FlyoutPage.Detail`

![Routes Page](https://user-images.githubusercontent.com/3520532/169628294-5e84f097-af78-4f50-8540-7dc5d483aff0.png)

Finally, because the `FlyoutPage.Detail` is a **NavigationPage**, we can 'drill-down' navigate from the RoutesPage to a "RouteDetailPage" while still technically being on the Routes page that was selected in the menu.

![Route Details Page](https://user-images.githubusercontent.com/3520532/169628313-e22e63f2-b662-4138-ab92-71b9b1f88ab1.png)


