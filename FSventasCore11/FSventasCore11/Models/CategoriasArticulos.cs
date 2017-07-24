﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FSventasCore11.Models
{
    public class CategoriasArticulos
    {
        [Key]
        public int CategoriaId { get; set; }
        [Required(ErrorMessage = "Este Campo es Requerido")]
        [Display(Name = "Introducir Nombre de Categoria")]
        public string Nombre { get; set; }
    }
}
