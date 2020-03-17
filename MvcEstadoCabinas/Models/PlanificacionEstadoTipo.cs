using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcPlanificacionCabinas.Models
{
    public enum PlanificacionEstadoTipoEnum
    {
        Verificado,
        //
        Pendiente,
        //
        Lanzada,
        //
        [Description("En curso")]
        En_Curso,
        //
        [Description("Avería")]
        Averia,
        //
        [Description("No pesada")]
        No_Pesada,
        //
        Finalizada,
        //
        Cancelada,
    }
    public class PlanificacionEstadoTipo
    {
        protected PlanificacionEstadoTipo() { } //For EF

        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PlanificacionEstadoTipoId { get; set; }
        
        public int? Valor { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [Required, MaxLength(100)]
        public string Description { get; set; }
    }
}