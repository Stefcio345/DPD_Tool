using System.Diagnostics;
using DPD_App;
using DPD_App.Components;
using DPD_App.Models;
using MudBlazor.Services;

//Create necessary directories

Directory.CreateDirectory(Globals.SaveLocation);
SaveKeeper.LoadState();

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseUrls("http://0.0.0.0:5000");

// Add mudBlazor services
builder.Services.AddSingleton<AppState>();
builder.Services.AddScoped<AppState>();

builder.Services.AddMudServices();
builder.WebHost.UseStaticWebAssets();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

app.UseMiddleware<RequestCaptureMiddleware>();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to chang
    // e this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

if (app.Environment.IsProduction())
{
    try
    {
        var url = "http://localhost:5000"; // Change this to match your production URL if necessary.
        Task.Run(() => OpenBrowser(url));
    }
    catch (Exception e)
    {
        Console.WriteLine(e);
    }
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

SaveKeeper.SaveState(SaveType.DEFAULT);

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.MapGet("/Test", () => "Hello, World!");

app.Run();

static void OpenBrowser(string url)
{
    try
    {
        Process.Start(new ProcessStartInfo
        {
            FileName = url,
            UseShellExecute = true
        });
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Could not launch browser: {ex.Message}");
    }
}