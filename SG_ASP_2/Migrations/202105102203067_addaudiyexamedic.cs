namespace SG_ASP_2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addaudiyexamedic : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExaMedicoes",
                c => new
                    {
                        IdExMed = c.Int(nullable: false, identity: true),
                        Examen = c.String(),
                    })
                .PrimaryKey(t => t.IdExMed);
            
            CreateTable(
                "dbo.Auditorias",
                c => new
                    {
                        IdAudi = c.Int(nullable: false, identity: true),
                        IdAtenciones = c.Int(nullable: false),
                        ExaCom = c.Boolean(nullable: false),
                        ExaCom1 = c.String(maxLength: 20),
                        DatInc = c.Boolean(nullable: false),
                        DatInc1 = c.String(maxLength: 20),
                        AptErr = c.Boolean(nullable: false),
                        AptErr1 = c.String(maxLength: 20),
                        FaFiMe = c.Boolean(nullable: false),
                        FaFiMe1 = c.String(maxLength: 20),
                        FaFiPa = c.Boolean(nullable: false),
                        FaFiPa1 = c.String(maxLength: 20),
                        Restri = c.Boolean(nullable: false),
                        Restri1 = c.String(maxLength: 20),
                        Contro = c.Boolean(nullable: false),
                        Contro1 = c.String(maxLength: 20),
                        Diagno = c.Boolean(nullable: false),
                        Diagno1 = c.String(maxLength: 20),
                        ErrLle = c.Boolean(nullable: false),
                        ErrLle1 = c.String(maxLength: 20),
                        ObNoRe = c.String(maxLength: 100),
                        EmSnOb = c.Boolean(nullable: false),
                        EmSnOb1 = c.String(maxLength: 20),
                        HorAud = c.Time(precision: 7),
                        FecAud = c.DateTime(storeType: "date"),
                        UserName = c.String(maxLength: 100),
                        IdMedico = c.Int(nullable: false),
                        OmiInt = c.Boolean(nullable: false),
                        OmiInt1 = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.IdAudi)
                .ForeignKey("dbo.Atenciones", t => t.IdAtenciones, cascadeDelete: true)
                .ForeignKey("dbo.Medicos", t => t.IdMedico, cascadeDelete: true)
                .Index(t => t.IdAtenciones)
                .Index(t => t.IdMedico);
            
            CreateTable(
                "dbo.AuditoriaExaMedicoes",
                c => new
                    {
                        Auditoria_IdAudi = c.Int(nullable: false),
                        ExaMedico_IdExMed = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Auditoria_IdAudi, t.ExaMedico_IdExMed })
                .ForeignKey("dbo.Auditorias", t => t.Auditoria_IdAudi, cascadeDelete: true)
                .ForeignKey("dbo.ExaMedicoes", t => t.ExaMedico_IdExMed, cascadeDelete: true)
                .Index(t => t.Auditoria_IdAudi)
                .Index(t => t.ExaMedico_IdExMed);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Auditorias", "IdMedico", "dbo.Medicos");
            DropForeignKey("dbo.AuditoriaExaMedicoes", "ExaMedico_IdExMed", "dbo.ExaMedicoes");
            DropForeignKey("dbo.AuditoriaExaMedicoes", "Auditoria_IdAudi", "dbo.Auditorias");
            DropForeignKey("dbo.Auditorias", "IdAtenciones", "dbo.Atenciones");
            DropIndex("dbo.AuditoriaExaMedicoes", new[] { "ExaMedico_IdExMed" });
            DropIndex("dbo.AuditoriaExaMedicoes", new[] { "Auditoria_IdAudi" });
            DropIndex("dbo.Auditorias", new[] { "IdMedico" });
            DropIndex("dbo.Auditorias", new[] { "IdAtenciones" });
            DropTable("dbo.AuditoriaExaMedicoes");
            DropTable("dbo.Auditorias");
            DropTable("dbo.ExaMedicoes");
        }
    }
}
