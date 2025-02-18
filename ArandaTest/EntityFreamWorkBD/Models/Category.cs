namespace EntityFreamWorkBD.Models;

public partial class Category
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public bool Active { get; set; }

    public DateTime CreateDate { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
