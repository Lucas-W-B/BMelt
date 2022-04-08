using System.ComponentModel.DataAnnotations;

namespace BMelt.ClassLibrary.Models
{
    public class MealPlan
    {
        [Key]
        public Guid Id { get; set; }
        public IEnumerable<Meal> Meals { get; set; }
    }
}
