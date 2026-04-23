# .NET 10 Upgrade Plan

## Execution Steps

Execute steps below sequentially one by one in the order they are listed.

1. Validate that a .NET 10 SDK required for this upgrade is installed on the machine and if not, help to get it installed.
2. Ensure that the SDK version specified in global.json files is compatible with the .NET 10 upgrade.
3. Upgrade BlazorHybridWithTelerikXaml\BlazorHybridWithTelerikXaml.csproj

## Settings

### Excluded projects

None.

### Aggregate NuGet packages modifications across all projects

No NuGet package modifications required.

### Project upgrade details

#### BlazorHybridWithTelerikXaml modifications

Project properties changes:
  - Target frameworks should be changed from `net6.0-android;net6.0-ios;net6.0-maccatalyst;net6.0-windows10.0.19041.0` to `net6.0-android;net6.0-ios;net6.0-maccatalyst;net6.0-windows10.0.19041.0;net10.0-windows`
