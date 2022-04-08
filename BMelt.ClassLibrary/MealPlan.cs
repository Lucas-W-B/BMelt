namespace BMelt.ClassLibrary
{
    public class MealPlan
    {
        public SortedDictionary<short, Recipe> Recipes { get; set; }
        public DateTime StartDate { get; set; }
    }
}
