using BMelt.App;
using BMelt.ClassLibrary.Models;
using BMelt.Services.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddTransient<HttpClient>(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration.GetSection("ServiceAddress").Value) });

builder.Services.AddScoped<IRecipeDataService, RecipeDataService>();
builder.Services.AddScoped<IItemDataService<Recipe>, RecipeDataService>();
builder.Services.AddScoped<IItemDataService<Author>, ItemDataService<Author>>();
builder.Services.AddScoped<IItemDataService<Cuisine>, ItemDataService<Cuisine>>();
builder.Services.AddScoped<IItemDataService<Ingredient>, ItemDataService<Ingredient>>();
builder.Services.AddScoped<IItemDataService<Meal>, ItemDataService<Meal>>();
builder.Services.AddScoped<IItemDataService<NutritionFact>, ItemDataService<NutritionFact>>();
builder.Services.AddScoped<IItemDataService<Step>, ItemDataService<Step>>();
builder.Services.AddScoped<IItemDataService<Tool>, ItemDataService<Tool>>();
builder.Services.AddScoped<IItemDataService<User>, ItemDataService<User>>();

await builder.Build().RunAsync();
