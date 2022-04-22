using BMelt.ClassLibrary.Models;
using BMelt.ClassLibrary.Repository;
using BMelt.ClassLibrary.Repository.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
builder.Services.AddDbContext<DatabaseContext>();
//TODO: DI for DB context + all of the repos
app.UseHttpsRedirection();

MapAuthorEndPoints(app);
//MapCuisineEndPoints(app);
//MapIngredientEndPoints(app);
//MapMealEndPoints(app);
//MapMealPlanEndPoints(app);
//MapNutritionFactEndPoints(app);
//MapRecipeEndPoints(app);
//MapStepEndPoints(app);
//MapToolEndPoints(app);
//MapUserEndPoints(app);

app.Run();

static void MapAuthorEndPoints(WebApplication app)
{
    app.MapGet("/author", async (IAuthorRepository repo) => await repo.GetAuthorsAsync());

    app.MapGet("/author/{id}", async (Guid id, IAuthorRepository repo) =>
    {
        return (await repo.GetAuthorAsync(id)) is Author author
                    ? Results.Ok(author)
                    : Results.NotFound();
    });

    app.MapPost("/author", async (Author author, IAuthorRepository repo) =>
    {
        await repo.AddAuthorAsync(author);
        return Results.Created($"/author/{author.Id}", author);
    }); 
    
    app.MapPut("/author/{id}", async (Guid id, Author author, IAuthorRepository repo) =>
    {
        var updatedAuthor = await repo.UpdateAuthorAsync(author);
        return updatedAuthor == null ? Results.NotFound() : Results.NoContent();
    });
    
    app.MapDelete("/author/{id}", async (Guid id, IAuthorRepository repo) =>
    {
        return await repo.DeleteAuthorAsync(id) ? Results.Ok() : Results.NotFound();
    });
}