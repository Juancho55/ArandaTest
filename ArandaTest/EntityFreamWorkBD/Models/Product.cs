namespace EntityFreamWorkBD.Models;

public partial class Product
{
    public long Id { get; set; }

    public int IdCategory { get; set; }

    public string Name { get; set; } = null!;

    public string ShortDescription { get; set; } = null!;

    public byte[] ImageP { get; set; } = null!;

    public bool Active { get; set; }

    public DateTime CreateDate { get; set; }

    public virtual Category IdCategoryNavigation { get; set; } = null!;
}
