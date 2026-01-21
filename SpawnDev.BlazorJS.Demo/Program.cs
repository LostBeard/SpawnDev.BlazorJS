using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SpawnDev;
using SpawnDev.BlazorJS;
using SpawnDev.BlazorJS.Demo;
using SpawnDev.BlazorJS.Demo.UnitTests;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// add BlazorJSRuntime (Javascript interop)
builder.Services.AddBlazorJSRuntime(out var JS);

// unit test services and the services they use
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSingleton<BlazorJSUnitTest>();
builder.Services.AddSingleton<CryptoService>();
builder.Services.AddSingleton<FileSystemAPIService>();
builder.Services.AddSingleton<TypedArrayTests>();
builder.Services.AddSingleton<MediaTests>();
builder.Services.AddSingleton<CacheTests>();

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// start the app using BlazorJSRunAsync
await builder.Build().BlazorJSRunAsync();
