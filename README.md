# Toolbelt.ComponentModel.Annotations.Resources [![NuGet Package](https://img.shields.io/nuget/v/Toolbelt.ComponentModel.Annotations.Resources.svg)](https://www.nuget.org/packages/Toolbelt.ComponentModel.Annotations.Resources/)

Built-in validation error messages for validation attributes such as `[Required]`, `[StringLength]`, etc., on your ASP.NET Core and Blazor apps will be shown localized after installing this NuGet package.

> **Warning**  
> ⚠️ This library touches undocumented areas and private implementations of the .NET runtime, using the "Reflection" technology. So please remember that **it might not be working on future .NET versions.**

## Usage

1. Install the NuGet package for the language you want to localize. The following command example shows the case for localizing standard validation error messages to Japanese.

```shell
dotnet add package Toolbelt.ComponentModel.Annotations.Resources.ja
```

2. Call the `AddSystemComponentModelAnnotationsLocalization()` extension method for a service collection at the startup of your apps.

```csharp
// Program.cs
...
using Toolbelt.Extensions.DependencyInjection;
...
builder.Services.AddSystemComponentModelAnnotationsLocalization();
...
```

After doing the above steps, you will see localized validation error messages on your ASP.NET Core and Blazor apps.

![](https://raw.githubusercontent.com/jsakamoto/Toolbelt.ComponentModel.Annotations.Resources/main/.assets/fig.001.png)

## Notice

Please remember to set the current thread culture on your apps the way you want. On a Blazor server app case, for example, you may have to implement your startup code like this:

```csharp
// Program.cs
...
using Toolbelt.Extensions.DependencyInjection;
...
var builder = WebApplication.CreateBuilder(args);
...
// 👇 Register services to the DI container involved with the localization feature.
builder.Services.AddLocalization(); 
...
builder.Services.AddSystemComponentModelAnnotationsLocalization();
...
var app = builder.Build();
...
// 👇 Configure the Request Localization middleware.
app.UseRequestLocalization(options =>
{
    var supportedCultures = new[] { "en", "ja" };
    options.AddSupportedCultures(supportedCultures);
    options.AddSupportedUICultures(supportedCultures);
});
...
app.Run();
```

**See also:** [🔗 _"ASP.NET Core Blazor globalization and localization" | Microsoft Docs_](https://docs.microsoft.com/aspnet/core/blazor/globalization-localization)

## Release Note

[Release notes](https://github.com/jsakamoto/Toolbelt.ComponentModel.Annotations.Resources/blob/main/RELEASE-NOTES.txt)

## License

[Mozilla Public License Version 2.0](https://github.com/jsakamoto/Toolbelt.ComponentModel.Annotations.Resources/blob/main/LICENSE)
