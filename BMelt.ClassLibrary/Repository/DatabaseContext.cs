using BMelt.ClassLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace BMelt.ClassLibrary.Repository
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<MealPlan> MealPlans { get; set; }
        public DbSet<NutritionFact> NutritionFacts { get; set; }
        public DbSet<Step> Steps { get; set; }
        public DbSet<Tool> Tools { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Cuisine> Cuisines { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"DataSource=BMelt.db;");
        }
    }
}
