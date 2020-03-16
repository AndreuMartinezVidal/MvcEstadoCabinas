using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcPlanificacionCabinas.Models
{
    [NotMapped]
    public class PlanificacionCabinasViewModel
    {
        public string Tubo { get; set; }
        public int recurso { get; set; }
        public string des_subseccion { get; set; }
        public string Order_cod { get; set; }
        public int material_cod { get; set; }
        public string descart { get; set; }
        public string Lote { get; set; }
        public DateTime fecha_inicio_Programada { get; set; } 
        public int? PlanificacionEstadoId { get; set; }
        public PlanificacionEstadoTipoEnum? PlanificacionEstadoTipoId { get; set; } = PlanificacionEstadoTipoEnum.Pendiente;
        public string Estado => PlanificacionEstadoTipoId?.GetEnumDescription();
        public string Comentarios { get; set; }
        public string UsuarioModificacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public int? Prioridad { get; set; }
    }
}