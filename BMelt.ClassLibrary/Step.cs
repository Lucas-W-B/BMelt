namespace BMelt.ClassLibrary
{
    public class Step
    {
        public int Order { get; set; }
        public bool IsSubStep { get; set; }
        public string PreText { get; set; }
        public Ingredient Ingredient { get; set; }
        public string PostText { get; set; }
        public TimeSpan Length { get; set; }
    }
}
