# gRPC Demo

This contains an ASP.NET project as the gRPC server. The client apps are built by the .NET MAUI project. 
To use this demo:

## Step 1 - Deploy the gRPC web app service

1. Set the web project as startup project
2. Rebuild 
3. Start without debugging Ctrl+F5)

You should see the app is running in its own process, output to a console window:

![server](https://github.com/LanceMcCarthy/CustomMauiExamples/assets/3520532/1474e680-1703-4a66-9c80-30a7b3c2724a)

## Step 2 - Deploy the client application(s)

1. Right-click on the MAUI project, select as startup project
2. Choose target platform (Windows is default)
3. Rebuild
4. Start with or without debugging (Ctrl+F5 is best)

![client-windows](https://github.com/LanceMcCarthy/CustomMauiExamples/assets/3520532/f6de7073-160d-477a-aab0-4c483902b8d0)

You will then see the following successful result:

![client-success](https://github.com/LanceMcCarthy/CustomMauiExamples/assets/3520532/f52a6b7c-5da2-4970-842d-6e7f7f2959ab)

You can continue making requests. The request history will be displayed in the DataGrid
