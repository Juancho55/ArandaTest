using EntityFreamWorkBD.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFreamWorkBD.Data;

public partial class ArandaTestDbContext : DbContext
{
    public ArandaTestDbContext()
    {
    }

    public ArandaTestDbContext(DbContextOptions<ArandaTestDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-QHNP2HL\\SQLEXPRESS;Database=ArandaTest;User ID=sa;Password=Fenix2121@; Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Category__3214EC072195F135");

            entity.ToTable("Category");

            entity.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasColumnName("Create_Date");
            entity.Property(e => e.Name).HasMaxLength(200);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Product__3214EC07FB131180");

            entity.ToTable("Product");

            entity.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasColumnName("Create_Date");
            entity.Property(e => e.IdCategory).HasColumnName("Id_Category");
            entity.Property(e => e.ImageP).HasColumnType("image");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.ShortDescription).HasMaxLength(300);

            entity.HasOne(d => d.IdCategoryNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdCategory)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Category");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
