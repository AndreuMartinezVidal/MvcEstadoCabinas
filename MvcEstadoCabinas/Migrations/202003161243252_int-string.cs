namespace MvcPlanificacionCabinas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class intstring : DbMigration
    {
        public override void Up()
        {
            //AlterColumn("dbo.Planificacion_Cabinas", "recurso", c => c.Int(nullable: false));
            //AlterColumn("dbo.Planificacion_Cabinas", "material_cod", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Planificacion_Cabinas", "material_cod", c => c.String());
            AlterColumn("dbo.Planificacion_Cabinas", "recurso", c => c.String());
        }
    }
}
