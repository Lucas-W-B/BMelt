using System.ComponentModel.DataAnnotations;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
namespace BMelt.ClassLibrary.Models
{
    public class MealPlan
    {
        [Key]
        public Guid Id { get; set; }
        public IEnumerable<Meal> Meals { get; set; }
    }
}
