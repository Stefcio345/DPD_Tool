using System.Diagnostics;
using DPD_App;
using DPD_App.Components;
using DPD_App.Models;
using Microsoft.AspNetCore.Components;
using MudBlazor.Services;

//Create necessary directories
Directory.CreateDirectory(Globals.SaveLocation);
SaveKeeper.LoadState();

// Define hostname
for (int i = 0; i < args.Length; i++)
{
    if (args[i] == "--InstanceName" && i + 1 < args.Length)
    {
        Globals.HostName = args[i + 1];
    }
}

var builder = WebApplication.CreateBuilder(args);

// Add MudBlazor services
builder.Services.AddMudServices();

builder.Services.AddSingleton<AppState>();
builder.Services.AddScoped<AppState>();

builder.Services.AddScoped<AuthService>();

builder.WebHost.UseStaticWebAssets();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

SaveKeeper.SaveState(SaveType.DEFAULT);

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