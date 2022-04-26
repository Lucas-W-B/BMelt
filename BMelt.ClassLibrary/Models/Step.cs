using System.ComponentModel.DataAnnotations;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
namespace BMelt.ClassLibrary.Models
{
    public class Step
    {
        [Key]
        public Guid Id { get; set; }
        public int Order { get; set; }
        public bool IsSubStep { get; set; }
        public string PreText { get; set; }
        public Ingredient Ingredient { get; set; }
        public string PostText { get; set; }
        public TimeSpan Length { get; set; }
    }
}
