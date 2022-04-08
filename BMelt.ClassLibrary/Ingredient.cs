using BMelt.ClassLibrary.Enums;

namespace BMelt.ClassLibrary
{
    public class Ingredient
    {
        public string Name { get; set; }
        public uint Count { get; set; }
        public MeasurementType Measurement { get; set; }
        public Format Format { get; set; }
    }
}
