using System.ComponentModel.DataAnnotations;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
namespace BMelt.ClassLibrary.Models
{
    public class Recipe
    {
        [Key]
        public Guid Id { get; set; }
        public Author Author { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public IEnumerable<Cuisine> Cuisines { get; set; }
        public IEnumerable<Step> Steps { get; set; }
        public IEnumerable<NutritionFact> NutritionFacts { get; set; }
        public IEnumerable<Tool> Tools { get; set; }
    }
}
