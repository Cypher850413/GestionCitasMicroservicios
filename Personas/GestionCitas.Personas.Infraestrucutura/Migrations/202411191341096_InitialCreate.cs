namespace GestionCitas.Personas.Infraestrucutura.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Medicos",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        especialidad = c.String(),
                        Nombre = c.String(),
                        Apellido = c.String(),
                        TipoDocumento = c.String(),
                        Documento = c.String(),
                        Correo = c.String(),
                        NumeroContacto = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Pacientes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Eps = c.String(),
                        Nombre = c.String(),
                        Apellido = c.String(),
                        TipoDocumento = c.String(),
                        Documento = c.String(),
                        Correo = c.String(),
                        NumeroContacto = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Pacientes");
            DropTable("dbo.Medicos");
        }
    }
}
