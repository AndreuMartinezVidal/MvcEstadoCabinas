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
        private PlanificacionEstadoTipo(PlanificacionEstadoTipoEnum @enum)
        {
            PlanificacionEstadoTipoId = (int)@enum;
            Description = @enum.GetEnumDescription();
            Name = @enum.ToString();
        }

        protected PlanificacionEstadoTipo() { } //For EF

        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PlanificacionEstadoTipoId { get; set; }
        public int Valor { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(100), NotMapped]
        public string Description { get; } 

        public static implicit operator PlanificacionEstadoTipo(PlanificacionEstadoTipoEnum @enum)
            => new PlanificacionEstadoTipo(@enum);

        public static implicit operator PlanificacionEstadoTipoEnum(PlanificacionEstadoTipo PlanificacionEstadoTipo)
            => (PlanificacionEstadoTipoEnum)PlanificacionEstadoTipo.PlanificacionEstadoTipoId;
    }
}