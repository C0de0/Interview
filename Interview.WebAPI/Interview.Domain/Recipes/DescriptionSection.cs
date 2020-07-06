namespace Interview.Domain.Recipes
{
    public class DescriptionSection : IValueObject
    {
        public string Title { get; set; }
        public string Content { get; set; }
    }
}