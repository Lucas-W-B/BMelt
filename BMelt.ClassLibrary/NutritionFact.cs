using BMelt.ClassLibrary.Enums;

namespace BMelt.ClassLibrary
{
    public class NutritionFact
    {
        public FactType FactType { get; set; }
        public uint Count { get; set; }
        public uint AltCount { get; set; }
        public double Percentage { get; set; }
        public MeasurementType MeasurementType { get; set; }
        public MeasurementType AltMeasurementType { get; set; }
    }
}
