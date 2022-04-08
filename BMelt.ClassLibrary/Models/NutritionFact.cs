using BMelt.ClassLibrary.Enums;
using System.ComponentModel.DataAnnotations;

namespace BMelt.ClassLibrary.Models
{
    public class NutritionFact
    {
        [Key]
        public Guid Id { get; set; }
        public FactType FactType { get; set; }
        public uint Count { get; set; }
        public uint AltCount { get; set; }
        public double Percentage { get; set; }
        public MeasurementType MeasurementType { get; set; }
        public MeasurementType AltMeasurementType { get; set; }
    }
}
