namespace MvcPlanificacionCabinas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PrioridadNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PlanificacionEstado", "Prioridad", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PlanificacionEstado", "Prioridad", c => c.Int(nullable: false));
        }
    }
}
