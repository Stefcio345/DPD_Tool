using System.Xml.Serialization;
using DPD_App;
using DPD_App.Components;
using MudBlazor;
using MudBlazor.Services;

//Create necessary directories

Directory.CreateDirectory(Globals.SaveLocation);
Globals.LoadState();

var builder = WebApplication.CreateBuilder(args);

// Add mudBlazor services
builder.Services.AddSingleton<AppState>();
builder.Services.AddScoped<AppState>();

builder.Services.AddMudServices();
builder.Services.AddMudMarkdownServices();
builder.WebHost.UseStaticWebAssets();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to chang
    // e this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

Globals.SaveState();
//TODO repair global variables

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();