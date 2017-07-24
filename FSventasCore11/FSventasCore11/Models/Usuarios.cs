using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FSventasCore11.Models
{
    public class Usuarios
    {
        [Key]
        public int UsuarioId { get; set; }
        [Required(ErrorMessage = "Este Campo es Requerido")]
        [Display(Name = "Introducir su Nombre")]
        public string Nombres { get; set; }
        [Required(ErrorMessage = "Este Campo es Requerido")]
        [Display(Name = "Introducir su Contraseña")]
        [DataType(DataType.Password)]
        public string Contraseña { get; set; }
        [NotMapped]
        [Compare("Password", ErrorMessage = "Contraseña no Concide")]
        public string ComfimarContraseña { get; set; }
        [ForeignKey("TipoUsuarios")]
        public int TipoId { get; set; }
        public virtual TipoUsuarios TipoUsuarios { get; set; }
    }
}
