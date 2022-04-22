using System.ComponentModel.DataAnnotations;

namespace BMelt.ClassLibrary.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
