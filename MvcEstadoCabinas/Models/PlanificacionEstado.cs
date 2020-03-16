using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcPlanificacionCabinas.Models
{
    public class PlanificacionEstado
    {
        public PlanificacionEstado(string order_cod)
        {
            Order_cod = order_cod;
        }

        public static PlanificacionEstado Create(string order_cod)
        {
            return new PlanificacionEstado(order_cod);
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PlanificacionEstadoId { get; set; }

        [Required]
        public PlanificacionEstadoTipoEnum PlanificacionEstadoTipoId { get; set; } = PlanificacionEstadoTipoEnum.Pendiente;

        [NotMapped]
        public string Estado => PlanificacionEstadoTipoId.GetEnumDescription();

        [Required, DisplayName("OF")]
        public string Order_cod { get; set; }

        [DisplayName("Comentario cabina")]
        public string Comentarios { get; set; }

        [Required, DisplayName("Modificado por")]
        public string UsuarioModificacion { get; set; } = System.Web.HttpContext.Current.User.Identity.Name;

        [Required, DisplayName("Modificado"), DataType(DataType.DateTime)]
        public DateTime FechaModificacion { get; set; } = DateTime.Now;

        public int? Prioridad { get; set; }
    }
}