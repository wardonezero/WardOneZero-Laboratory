using DataFormulaLibrary.Data;
using Microsoft.EntityFrameworkCore;
using ServiceFormulaLibrary;
using WardOneZeroCommerce.Components;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

string connectionString = builder.Configuration.GetConnectionString("Sqlite")!;

builder.Services.AddDbContext<DataContext>(option => option.UseSqlite(connectionString));
builder.Services.AddDbContext<AddressContext>(o => o.UseSqlite(connectionString));
builder.Services.AddDbContext<AttributeContext>(o => o.UseSqlite(connectionString));
builder.Services.AddDbContext<CatalogContext>(o => o.UseSqlite(connectionString));
builder.Services.AddDbContext<SalesContext>(o => o.UseSqlite(connectionString));
builder.Services.AddDbContext<UserContext>(o => o.UseSqlite(connectionString));

builder.Services.AddScoped(typeof(GenericDataService<>));
builder.Services.AddScoped(typeof(PictureService<>));
builder.Services.AddScoped<ProductService>();

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
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapGet("/console", () => Results.Redirect("/console/dashboard"));

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(WardOneZeroCommerce.Client._Imports).Assembly);

app.Run();
