using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ArandaTest.Models.ProductAPI
{
    public class ProductRequestModel
    {
        [Description("Id del producto")]
        public long Id { get; set; } = 0;
        [Required]
        [Description("Id de la categoria que va relacionada al producto")]
        public int IdCategory { get; set; }
        [Required, MinLength(3), MaxLength(100)]
        [Description("Nombre del producto. Maximo 100 caracteres y minimo 3")]
        public string Name { get; set; } = null!;
        [Required, MinLength(3), MaxLength(200)]
        [Description("Descripcion corta del producto. Minimo 3 caracteres y maximo 200")]
        public string ShortDescription { get; set; } = null!;
        [Required]
        [Description("Imagen del producto array de bytes")]
        public byte[] ImageP { get; set; } = null!;
        [Description("Estado del producto")]
        public bool? Active { get; set; } = null;
    }
}
