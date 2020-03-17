using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcPlanificacionCabinas.Models
{
    [Table("PlanificacionCabinas")]
    //[NotMapped]
    public class PlanificacionCabina
    {
        public string Tubo { get; set; }
        
        public int recurso { get; set; }
        
        public string des_subseccion { get; set; }

        [Key]
        public string Order_cod { get; set; }
        
        public int material_cod { get; set; }

        public string descart { get; set; }

        public string Lote { get; set; }
        
        [DataType(DataType.DateTime)]
        public DateTime fecha_inicio_Programada { get; set; }
    
        public PlanificacionEstado PlanificacionCabinasEstado { get; set; }
    }
}