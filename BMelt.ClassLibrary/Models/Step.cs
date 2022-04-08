using System.ComponentModel.DataAnnotations;

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
