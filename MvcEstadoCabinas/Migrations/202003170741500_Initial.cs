namespace MvcPlanificacionCabinas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PlanificacionCabinas",
                c => new
                {
                    Tubo = c.String(),
                    recurso = c.Int(nullable: false),
                    des_subseccion = c.String(),
                    Order_cod = c.String(nullable: false, maxLength: 128),
                    material_cod = c.Int(nullable: false),
                    descart = c.String(),
                    Lote = c.String(),
                    fecha_inicio_Programada = c.DateTime(nullable: false)
                })
                .PrimaryKey(t => t.Order_cod);
            
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
                        Prioridad = c.Int(),
                    })
                .PrimaryKey(t => t.PlanificacionEstadoId)
                .ForeignKey("dbo.PlanificacionEstadoTipo", t => t.PlanificacionEstadoTipoId, cascadeDelete: true)
                .Index(t => t.PlanificacionEstadoTipoId);
            
            CreateTable(
                "dbo.PlanificacionEstadoTipo",
                c => new
                    {
                        PlanificacionEstadoTipoId = c.Int(nullable: false),
                        Valor = c.Int(),
                        Name = c.String(nullable: false, maxLength: 100),
                        Description = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.PlanificacionEstadoTipoId);
            
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
                .PrimaryKey(t => t.PlanificacionHistoricoId)
                .ForeignKey("dbo.PlanificacionEstadoTipo", t => t.PlanificacionEstadoTipoId, cascadeDelete: true)
                .Index(t => t.PlanificacionEstadoTipoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PlanificacionHistorico", "PlanificacionEstadoTipoId", "dbo.PlanificacionEstadoTipo");
            DropForeignKey("dbo.PlanificacionEstado", "PlanificacionEstadoTipoId", "dbo.PlanificacionEstadoTipo");
            DropIndex("dbo.PlanificacionHistorico", new[] { "PlanificacionEstadoTipoId" });
            DropIndex("dbo.PlanificacionEstado", new[] { "PlanificacionEstadoTipoId" });
            DropIndex("dbo.PlanificacionCabinas", new[] { "PlanificacionCabinasEstado_PlanificacionEstadoId" });
            DropTable("dbo.PlanificacionHistorico");
            DropTable("dbo.PlanificacionEstadoTipo");
            DropTable("dbo.PlanificacionEstado");
            DropTable("dbo.PlanificacionCabinas");
        }
    }
}
