using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FSventasCore11.Models
{
    public class MarcasArticulos
    {
        [Key]
        public int MarcaId { get; set; }
        public string Nombre { get; set; }
    }
}
