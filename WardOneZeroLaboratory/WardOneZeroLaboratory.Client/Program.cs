using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WardOneZeroLaboratory.Client.Services;

WebAssemblyHostBuilder builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddScoped<ImageService>();
await builder.Build().RunAsync();
