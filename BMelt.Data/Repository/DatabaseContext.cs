using BMelt.ClassLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace BMelt.Data.Repository
{
    public class DatabaseContext : DbContext
    {
        private readonly string _dbPath = "";
        public DatabaseContext(string? dbPath = null)
        {
            if (dbPath != null)
            {
                _dbPath = dbPath;
            }
            else 
            {
                var folder = Environment.SpecialFolder.LocalApplicationData;
                var path = Environment.GetFolderPath(folder);
                _dbPath = Path.Join(path, "BMelt.db");
            }
        }
        
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

        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite($"Data Source={_dbPath}");
    }
}
