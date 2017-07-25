using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FSventasCore11.Models.Dirrecion
{
    public class Sectores
    {
        [Key]
        public int SectorId { get; set; }
        public string Nombre { get; set; }
        [ForeignKey("DistritosMunicipales")]
        public int DistritoId { get; set; }
        public virtual DistritosMunicipales DistritosMunicipales { get; set; }
    }
}
