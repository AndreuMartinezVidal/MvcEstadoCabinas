namespace MvcPlanificacionCabinas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.Planificacion_Cabinas",
            //    c => new
            //        {
            //            Order_cod = c.String(nullable: false, maxLength: 128),
            //            Tubo = c.String(),
            //            recurso = c.String(),
            //            des_subseccion = c.String(),
            //            material_cod = c.String(),
            //            descart = c.String(),
            //            Lote = c.String(),
            //            fecha_inicio_Programada = c.DateTime(nullable: false),
            //            PlanificacionCabinasEstado_PlanificacionEstadoId = c.Int(),
            //        })
            //    .PrimaryKey(t => t.Order_cod)
            //    .ForeignKey("dbo.PlanificacionEstado", t => t.PlanificacionCabinasEstado_PlanificacionEstadoId)
            //    .Index(t => t.PlanificacionCabinasEstado_PlanificacionEstadoId);

            CreateTable(
                "dbo.PlanificacionEstadoTipo",
                c => new
                {
                    PlanificacionEstadoTipoId = c.Int(nullable: false),
                    Name = c.String(nullable: false),
                    Valor = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.PlanificacionEstadoTipoId);

            CreateTable(
                "dbo.PlanificacionEstado",
                c => new
                {
                    PlanificacionEstadoId = c.Int(nullable: false, identity: true),
                    PlanificacionEstadoTipoId = c.Int(nullable: false),
                    Order_cod = c.String(nullable: false),
                    Comentarios = c.String(),
                    UsuarioModificacion = c.String(nullable: false),
                    FechaModificacion = c.DateTime(nullable: false),
                    Prioridad = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.PlanificacionEstadoId);

            CreateTable(
                "dbo.PlanificacionHistorico",
                c => new
                {
                    PlanificacionHistoricoId = c.Int(nullable: false, identity: true),
                    PlanificacionEstadoTipoId = c.Int(nullable: false),
                    Order_cod = c.String(nullable: false),
                    Comentarios = c.String(),
                    UsuarioModificacion = c.String(nullable: false),
                    FechaModificacion = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.PlanificacionHistoricoId);

        }

        public override void Down()
        {
            //DropForeignKey("dbo.Planificacion_Cabinas", "PlanificacionCabinasEstado_PlanificacionEstadoId", "dbo.PlanificacionEstado");
            //DropIndex("dbo.Planificacion_Cabinas", new[] { "PlanificacionCabinasEstado_PlanificacionEstadoId" });
            //DropTable("dbo.PlanificacionHistorico");
            //DropTable("dbo.PlanificacionEstado");
            //DropTable("dbo.Planificacion_Cabinas");
        }
    }
}
