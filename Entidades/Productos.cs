using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BLAZORREGISTRO.Entidades
{
    public partial class Productos
    {
        [Key]
        public int ProductoId { get; set; }

        [Required(ErrorMessage ="Es obligatorio introducir la descripción.")]
        public string? Descripcion { get; set; }

        [Required(ErrorMessage ="Es obligatorio introducir la existencia")]
        public decimal Existencia { get; set; }

        [Required(ErrorMessage = "El Campo \"Costo\"está vacío. Por favor indique un costo.")]
        [Range(1,int.MaxValue, ErrorMessage ="El costo debe estar dentro del rango permitido")]
        public decimal Costo { get; set; }
        public decimal ValorInventario { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir el Precio")]
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir la Ganancia")]
        public decimal Ganancia{ get; set; }

        [ForeignKey("ProductoId")]

        public List<ProductosDetalle> Detalle { get; set; } = new List<ProductosDetalle>();
    }
}