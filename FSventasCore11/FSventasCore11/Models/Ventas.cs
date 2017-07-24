using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace FSventasCore11.Models
{
    public class Ventas
    {
        [Key]
        public int VentaId { get; set; }
        [Required]
        public int ArticuloId { get; set; }
        [Required]
        public string articulo { get; set; }
        [Required]
        public int Cantidad { get; set; }
        [Required]
        public DateTime Fecha { get; set; }
        [Required]
        public decimal Total { get; set; }

        public Ventas()
        {

        }
    }
}
