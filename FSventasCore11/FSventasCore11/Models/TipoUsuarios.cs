using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FSventasCore11.Models
{
    public class TipoUsuarios
    {
        [Key]
        public int TipoId { get; set; }
        [Required(ErrorMessage = "Es Requerido")]
        [Display(Name = "Introducir el Nombre de Tipo de Usuarios")]
        public string Nombre { get; set; }

    }
}
