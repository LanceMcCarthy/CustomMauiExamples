# .NET 10 Upgrade Report

## Project target framework modifications

| Project name                          | Old Target Framework                                                       | New Target Framework                                                              |
|:--------------------------------------|:--------------------------------------------------------------------------:|:---------------------------------------------------------------------------------:|
| BlazorHybridWithTelerikXaml.csproj    | net9.0-android;net9.0-ios;net9.0-maccatalyst                               | net10.0-android;net10.0-ios;net10.0-maccatalyst / net10.0-windows10.0.19041.0    |

## NuGet Packages

| Package Name                                       | Old Version | New Version |
|:---------------------------------------------------|:-----------:|:-----------:|
| Microsoft.Maui.Controls                            | 9.0.120     | 10.0.51     |
| Microsoft.AspNetCore.Components.WebView.Maui       | 9.0.120     | 10.0.51     |

## All commits

| Commit ID  | Description                                                                     |
|:-----------|:--------------------------------------------------------------------------------|
| 132b553c   | Commit upgrade plan                                                             |
| 6c60bf03   | Refactor BlazorHybridWithTelerikXaml.csproj formatting                         |
| e1450c2e   | Remove BOM from XAML files for consistency                                      |
| 3689bd52   | Build succeeded - upgraded TargetFrameworks and packages to .NET 10             |
| 962fc923   | Update BlazorHybridWithTelerikXaml.csproj to .NET 9 and packages               |

## Project feature upgrades

### BlazorHybridWithTelerikXaml

- Updated `TargetFrameworks` to `net10.0-android;net10.0-ios;net10.0-maccatalyst` (non-Windows) and `net10.0-windows10.0.19041.0` (Windows-conditional). The Windows-conditional now correctly targets only Windows to avoid Android/iOS SDK resolution issues on Windows machines.
- Updated `Microsoft.Maui.Controls` from `9.0.120` to `10.0.51`.
- Updated `Microsoft.AspNetCore.Components.WebView.Maui` from `9.0.120` to `10.0.51`.
- `Telerik.UI.for.Maui` remains at version `3.0.0` as no net10.0-compatible version was found on the accessible NuGet feeds (Telerik uses a private feed).

## Next steps

- **Telerik.UI.for.Maui**: Check the [Telerik NuGet feed](https://nuget.telerik.com) for a version of `Telerik.UI.for.Maui` that supports .NET 10 targets (net10.0-android, net10.0-ios, net10.0-maccatalyst) and update the package reference when available.
- **Android/iOS/Mac builds**: These platform targets should be built and tested on appropriate machines (Mac for iOS/MacCatalyst, Windows or Mac for Android) with the correct workloads and MAUI SDK installed.
