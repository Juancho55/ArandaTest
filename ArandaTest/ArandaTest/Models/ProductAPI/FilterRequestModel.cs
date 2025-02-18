using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ArandaTest.Models.ProductAPI
{
    public class FilterRequestModel
    {
        [Required]
        [Description("Es la opcion de filtro 1 = Nanme, 2 = ShortDescription, 3 = Category")]
        public int FilterOption { get; set; }
        [Description("Filtra por la categoria")]
        public string Category { get; set; } = null!;
        [Description("Filtra por la descripcion corta")]
        public string ShortDescription { get; set; } = null!;
        [Description("Filtra por el nombre")]
        public string Name { get; set; } = null!;
    }
}
