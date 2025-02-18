using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ArandaTest.Models.ProductAPI
{
    public class PageAndOrderRequestModel
    {
        [Required]
        [Description("Pagina actual")]
        public int PageCurrent { get; set; }
        [Required]
        [Description("Cantidad de registros por pagina")]
        public int PageSize { get; set; }
        [Description("Para ordenar por el nombre del producto, true = ascendente, false = desendente, null = no se tiene en cuenta")]
        public bool? OrderByName { get; set; } = null;
        [Description("Para ordenar por la categoria, true = ascendente, false = desendente, null = no se tiene en cuenta - Nota: Se pueden enviar los dos.")]
        public bool? OrderByCategory { get; set; } = null;
    }
}
