namespace GestionCitas.Citas.Infraestructura.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Citas",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                        Lugar = c.String(),
                        PacienteId = c.Guid(nullable: false),
                        MedicoId = c.Guid(nullable: false),
                        Estado = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Citas");
        }
    }
}
