using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcPlanificacionCabinas.Models
{
    public class PlanificacionHistorico
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PlanificacionHistoricoId { get; set; }

        [Required]
        public int PlanificacionEstadoTipoId { get; set; } = (int)PlanificacionEstadoTipoEnum.Pendiente;


        [Required, DisplayName("OF")]
        public string Order_cod { get; set; }

        [DisplayName("Comentario cabina")]
        public string Comentarios { get; set; }

        [Required, DisplayName("Modificado por")]
        public string UsuarioModificacion { get; set; } = System.Web.HttpContext.Current.User.Identity.Name;

        [Required, DisplayName("Modificado"), DataType(DataType.DateTime)]
        public DateTime FechaModificacion { get; set; } = DateTime.Now;

        public PlanificacionEstadoTipo PlanificacionEstadoTipo { get; set; }
    }
}