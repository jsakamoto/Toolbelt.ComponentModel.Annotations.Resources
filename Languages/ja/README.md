# Toolbelt.ComponentModel.Annotations.Resources.ja [![NuGet Package](https://img.shields.io/nuget/v/Toolbelt.ComponentModel.Annotations.Resources.ja.svg)](https://www.nuget.org/packages/Toolbelt.ComponentModel.Annotations.Resources.ja/)

この NuGet パッケージをインストールすると、ASP.NET Core および Blazor アプリに組み込みの、`[Required]` や `[StringLength]` などの検証属性に対する検証エラーメッセージが、日本語化されて表示されるようになります。

> **Warning**  
> ⚠️ このライブラリは、リフレクションを使用して、文書化されていない、.NET ランタイムの非公開の実装に触れています。そのため、**将来の .NET バージョンでは動作しない可能性がある**ことをご承知おきください。

## 使い方

1. この NuGet パッケージをプロジェクトに追加します。下記は dotnet コマンドを使ってこれを行なう例です。

```shell
dotnet add package Toolbelt.ComponentModel.Annotations.Resources.ja
```

2. プログラムの開始時、サービスコレクションに対して `AddSystemComponentModelAnnotationsLocalization()` 拡張メソッドを呼び出します。

```csharp
// Program.cs
...
using Toolbelt.Extensions.DependencyInjection;
...
builder.Services.AddSystemComponentModelAnnotationsLocalization();
...
```

以上の手順を済ませると、ASP.NET Core および Blazor アプリ上で、日本語化された標準の検証エラーメッセージが表示されます。

![](https://raw.githubusercontent.com/jsakamoto/Toolbelt.ComponentModel.Annotations.Resources/main/.assets/fig.001.png)

## 注意点

アプリの現在のスレッドカルチャを望む方法で設定することを忘れないでください。例えば Blazor サーバーアプリの場合、次のようなスタートアップコードを実装する必要があるかもしれません。

```csharp
// Program.cs
...
using Toolbelt.Extensions.DependencyInjection;
...
var builder = WebApplication.CreateBuilder(args);
...
// 👇 ローカライズ機能に関するサービス群を DI コンテナに登録します。
builder.Services.AddLocalization(); 
...
builder.Services.AddSystemComponentModelAnnotationsLocalization();
...
var app = builder.Build();
...
// 👇 要求毎のローカライズミドルウェアを構成します。
app.UseRequestLocalization(options =>
{
    var supportedCultures = new[] { "en", "ja" };
    options.AddSupportedCultures(supportedCultures);
    options.AddSupportedUICultures(supportedCultures);
});
...
app.Run();
```

**参考:** [🔗 _"ASP.NET Core Blazor のグローバリゼーションおよびローカライズ" | Microsoft Docs_](https://docs.microsoft.com/aspnet/core/blazor/globalization-localization)

## リリースノート

[リリースノートはこちら](https://github.com/jsakamoto/Toolbelt.ComponentModel.Annotations.Resources/blob/main/Languages/ja/RELEASE-NOTES.txt)

## ライセンス

[Mozilla Public License Version 2.0](https://github.com/jsakamoto/Toolbelt.ComponentModel.Annotations.Resources/blob/main/LICENSE)

検証エラーメッセージの日本語訳には、[Bing Microsoft Translater](https://www.bing.com/translator) を使用しました。
