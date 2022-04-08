using BMelt.ClassLibrary.Enums;

namespace BMelt.ClassLibrary
{
    public class Recipe
    {
        public Author Author { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public IEnumerable<Cuisine> Cuisines { get; set; }
        public IEnumerable<Step> Steps { get; set; }
        public IEnumerable<NutritionFact> NutritionFacts { get; set; }
        public IEnumerable<Tool> Tools { get; set; }
    }
}
