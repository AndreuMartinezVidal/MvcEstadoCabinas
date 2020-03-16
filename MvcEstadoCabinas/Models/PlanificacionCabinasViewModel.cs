using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcPlanificacionCabinas.Models
{
    [NotMapped]
    public class PlanificacionCabinasViewModel
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
        [Display(Name = "Fecha"),DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
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