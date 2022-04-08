using System.ComponentModel.DataAnnotations;

namespace BMelt.ClassLibrary.Models
{
    public class Tool
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool RequiresSupervision { get; set; }
    }
}
