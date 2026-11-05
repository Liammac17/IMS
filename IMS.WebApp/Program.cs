using IMS.WebApp.Components;
using IMS.UseCases.PluginInterfaces;
using IMS.Plugins.InMemory;
using IMS.UseCases.Inventories;
using IMS.UseCases.Inventories.Interfaces;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents();

//how long to keep object in memory

//created on the first instance it is needed, then stored in application until disposed
builder.Services.AddSingleton<IInventoryRepository, InventoryRepository>();
//created every time it requires the use case, then disposed right after
builder.Services.AddTransient<IViewInventoryByName, ViewInventoryByName>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>();

app.Run();
