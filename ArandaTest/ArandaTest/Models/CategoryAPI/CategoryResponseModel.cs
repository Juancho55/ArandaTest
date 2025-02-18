namespace ArandaTest.Models.CategoryAPI
{
    public class CategoryResponseModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public bool Active { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
