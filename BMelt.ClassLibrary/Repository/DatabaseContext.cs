using BMelt.ClassLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace BMelt.ClassLibrary.Repository
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Recipe> Recipes => Set<Recipe>();
        public DbSet<Ingredient> Ingredients => Set<Ingredient>();
        public DbSet<Author> Authors => Set<Author>();
        public DbSet<MealPlan> MealPlans => Set<MealPlan>();
        public DbSet<NutritionFact> NutritionFacts => Set<NutritionFact>();
        public DbSet<Step> Steps => Set<Step>();
        public DbSet<Tool> Tools => Set<Tool>();
        public DbSet<Meal> Meals => Set<Meal>();
        public DbSet<Cuisine> Cuisines => Set<Cuisine>();
        public DbSet<User> Users => Set<User>();
    }
}
