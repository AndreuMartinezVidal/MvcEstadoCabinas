using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcPlanificacionCabinas.Models
{
    [Table("Planificacion_Cabinas")]
    public class PlanificacionCabina
    {
        public string Tubo { get; set; }
        
        [Display(Name = "Recurso")]
        public int recurso { get; set; }
        
        [Display(Name = "Subsección")]
        public string des_subseccion { get; set; }

        [Display(Name = "OF"), Key]
        public string Order_cod { get; set; }
        
        [Display(Name = "Material")]
        public int material_cod { get; set; }

        [Display(Name = "Descripción")]
        public string descart { get; set; }

        [Display(Name = "Lote")]
        public string Lote { get; set; }
        
        [DataType(DataType.DateTime)]
        [Display(Name = "Fecha")]
        public DateTime fecha_inicio_Programada { get; set; }
    
        public PlanificacionEstado PlanificacionCabinasEstado { get; set; }
    }
}