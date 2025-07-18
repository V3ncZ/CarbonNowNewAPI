using CarbonNow.Web;
using CarbonNow.Web.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddMudServices();
builder.Services.AddTransient<TransportAPI>();
builder.Services.AddTransient<ElectricalItemAPI>();

// Registra HttpClient padrão para consumo da API
builder.Services.AddHttpClient("API", client => {
    client.BaseAddress = new Uri(builder.Configuration["APIServer:Url"]!);
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});


await builder.Build().RunAsync();
