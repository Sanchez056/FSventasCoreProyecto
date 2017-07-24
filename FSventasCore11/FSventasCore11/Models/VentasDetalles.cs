using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace FSventasCore11.Models
{
    public class VentasDetalles
    {
        [Key]
        public int Id { get; set; }

        public int VentaId { get; set; }

        public string ArticuloId { get; set; }

        public decimal Precio { get; set; }

        public int Cantidad { get; set; }

        public VentasDetalles()
        {

        }
    }
}
