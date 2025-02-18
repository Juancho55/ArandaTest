namespace Models.Category
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public bool Active { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
