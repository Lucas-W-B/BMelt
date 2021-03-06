using BMelt.ClassLibrary.Enums;
using System.ComponentModel.DataAnnotations;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
namespace BMelt.ClassLibrary.Models
{
    public class Ingredient
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public uint Count { get; set; }
        public MeasurementType Measurement { get; set; }
        public Format Format { get; set; }
    }
}
