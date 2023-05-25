using BlazorDemo;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PraxisOnline.Api.Client;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddHttpClient();

builder.Services.AddScoped((services) => new WeatherForecastClient("https://localhost:7038", services.GetRequiredService<IHttpClientFactory>().CreateClient()));

await builder.Build().RunAsync();
