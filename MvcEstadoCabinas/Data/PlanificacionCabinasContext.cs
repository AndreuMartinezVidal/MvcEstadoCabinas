using MvcPlanificacionCabinas.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MvcPlanificacionCabinas.Data
{
    public class PlanificacionCabinasContext : DbContext
    {
        public PlanificacionCabinasContext() : base("PlanificacionCabinasContext")
        {
            //var context = ((IObjectContextAdapter)this.ObjectContext).ObjectContext;
            //context.MetadataWorkspace.GetItemCollection(System.Data.Entity.Core.Metadata.Edm.DataSpace.)
        }

        public DbSet<PlanificacionCabina> Planificaciones { get; set; }
        public DbSet<PlanificacionEstado> PlanificacionEstados { get; set; }
        public DbSet<PlanificacionEstadoTipo> PlanificacionEstadoTipos { get; set; }
        public DbSet<PlanificacionHistorico> PlanificacionHistoricos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}