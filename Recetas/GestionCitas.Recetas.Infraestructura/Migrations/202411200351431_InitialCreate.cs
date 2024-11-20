namespace GestionCitas.Recetas.Infraestructura.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Recetas",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Codigo = c.String(),
                        Descripcion = c.String(),
                        PacienteId = c.Guid(nullable: false),
                        Estado = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Recetas");
        }
    }
}
