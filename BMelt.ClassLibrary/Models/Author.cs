using System.ComponentModel.DataAnnotations;

namespace BMelt.ClassLibrary.Models
{
    public class Author
    {
        [Key]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Website { get; set; }
    }
}
