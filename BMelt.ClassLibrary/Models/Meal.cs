using System.ComponentModel.DataAnnotations;

namespace BMelt.ClassLibrary.Models
{
    public class Meal
    {
        [Key]
        public Guid Id { get; set; }
        public virtual Recipe Recipe { get; set; }
        public DateTime Date { get; set; }
    }
}
