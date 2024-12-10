using EPicrq.Resource;
using Menetrend.Data;
using Menetrend.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc.Authorization;
using MudBlazor;
using MudBlazor.Services;
using MudExtensions.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddControllers(); // Hozzáadás az API vezérlõk támogatásához
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddMudServices();

// Add services to the container.
builder.Services.Configure<DatabaseSettings>(
    builder.Configuration.GetSection("Connecting2Database"));

builder.Services.AddSingleton<ProductionServices>();
builder.Services.AddSingleton<AkcioServices>();
builder.Services.AddSingleton<AllomasServices>();
builder.Services.AddSingleton<JaratServices>();
builder.Services.AddSingleton<JegyServices>();
builder.Services.AddSingleton<UtasServices>();
builder.Services.AddSingleton<VarosServices>();
builder.Services.AddSingleton<VonatServices>();

builder.Services.AddMudServices(config =>
{
    config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomRight;

    config.SnackbarConfiguration.PreventDuplicates = false;
    config.SnackbarConfiguration.NewestOnTop = false;
    config.SnackbarConfiguration.ShowCloseIcon = true;
    config.SnackbarConfiguration.VisibleStateDuration = 10000;
    config.SnackbarConfiguration.HideTransitionDuration = 500;
    config.SnackbarConfiguration.ShowTransitionDuration = 500;
    config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
});
builder.Services.AddTransient<MudLocalizer, DictionaryMudLocalizer>();
builder.Services.AddMudExtensions();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

// Enable API Controllers
app.MapControllers(); // Vezérlõk regisztrálása (pl. MathController használatához)
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
