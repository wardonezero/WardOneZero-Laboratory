using SixLabors.ImageSharp;
using WardOneZeroLaboratory.Client.Pages;
using WardOneZeroLaboratory.Components;
using WardOneZeroLaboratory.Services;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddHttpClient();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapPost("/api/image/change-color", async (IFormFile file) =>
{
    if (file is null || file.Length == 0)
    {
        return Results.BadRequest("No file uploaded.");
    }

    using Stream stream = file.OpenReadStream();
    Image image = await Image.LoadAsync(stream);

    List<string> pixels = await ImageService.GetPixelsHexColorAsync(image);
    List<string> newPixels = await ImageService.ChangeImageColorAsync(pixels);
    Image newImage = await ImageService.PixelsToBitmapAsync(newPixels, image.Width, image.Height);
    string base64 = await ImageService.BitmapToBase64Async(newImage);

    return Results.Text(base64);
})
.DisableAntiforgery();

app.MapStaticAssets();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(ImageColorChange).Assembly);

app.Run();
