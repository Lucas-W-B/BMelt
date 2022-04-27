using BMelt.ClassLibrary.Models;
using BMelt.ClassLibrary.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DatabaseContext>();

builder.Services.AddScoped<IRecipeRepository, RecipeRepository>();
builder.Services.AddScoped<IRepository<Recipe>, RecipeRepository>();
builder.Services.AddScoped<IRepository<Author>, ItemRepository<Author>>();
builder.Services.AddScoped<IRepository<Cuisine>, ItemRepository<Cuisine>>();
builder.Services.AddScoped<IRepository<Ingredient>, ItemRepository<Ingredient>>();
builder.Services.AddScoped<IRepository<Meal>, ItemRepository<Meal>>();
builder.Services.AddScoped<IRepository<NutritionFact>, ItemRepository<NutritionFact>>();
builder.Services.AddScoped<IRepository<Step>, ItemRepository<Step>>();
builder.Services.AddScoped<IRepository<Tool>, ItemRepository<Tool>>();
builder.Services.AddScoped<IRepository<User>, ItemRepository<User>>();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

MapEndPoint<Author>(app);
MapEndPoint<Cuisine>(app);
MapEndPoint<Ingredient>(app);
MapEndPoint<Meal>(app);
MapEndPoint<NutritionFact>(app);
MapEndPoint<Recipe>(app);
MapEndPoint<Step>(app);
MapEndPoint<Tool>(app);
MapEndPoint<User>(app);

MapRecipeOverrides(app);

app.Run();

static void MapEndPoint<T>(WebApplication app)
{
    var typeName = typeof(T).Name;
    app.MapGet($"/{typeName}", async (IRepository<T> repo) => await repo.GetAsync());

    app.MapGet($"/{typeName}/{{id}}", async (Guid id, IRepository<T> repo) =>
    {
        return (await repo.GetAsync(id)) is T item
                    ? Results.Ok(item)
                    : Results.NotFound();
    });

    app.MapPost($"/{typeName}", async (T item, IRepository<T> repo) =>
    {
        var id = await repo.AddAsync(item);
        return Results.Created($"/{typeof(T)}/{id}", item);
    }); 
    
    app.MapPut($"/{typeName}/{{id}}", async (Guid id, T item, IRepository<T> repo) =>
    {
        var updatedItem = await repo.UpdateAsync(item);
        return updatedItem == null ? Results.NotFound() : Results.NoContent();
    });
    
    app.MapDelete($"/{typeName}/{{id}}", async (Guid id, IRepository<T> repo) =>
    {
        return await repo.DeleteAsync(id) ? Results.Ok() : Results.NotFound();
    });
}

static void MapRecipeOverrides(WebApplication app)
{
    app.MapGet($"/Recipe/{{cuisineId}}", async (Guid cuisineId, IRecipeRepository repo) => await repo.GetByCuisineAsync(cuisineId));
}