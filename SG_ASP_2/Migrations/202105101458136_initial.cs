namespace SG_ASP_2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Atenciones",
                c => new
                    {
                        IdAtenciones = c.Int(nullable: false, identity: true),
                        Local0 = c.String(maxLength: 20),
                        TipExa = c.String(maxLength: 20),
                        FecAte = c.DateTime(storeType: "date"),
                        NomApe = c.String(maxLength: 100),
                        DocIde = c.String(maxLength: 20),
                        Empres = c.String(maxLength: 100),
                        SubCon = c.String(maxLength: 100),
                        Proyec = c.String(maxLength: 100),
                        Perfil = c.String(maxLength: 100),
                        Area = c.String(maxLength: 100),
                        PueTra = c.String(maxLength: 100),
                        PeReAd = c.String(maxLength: 50),
                        Hora = c.Time(precision: 7),
                    })
                .PrimaryKey(t => t.IdAtenciones);
            
            CreateTable(
                "dbo.Medicinas",
                c => new
                    {
                        IdMedicina = c.Int(nullable: false, identity: true),
                        HorIng = c.Time(precision: 7),
                        HorSal = c.Time(precision: 7),
                        Aptitu = c.String(maxLength: 50),
                        FecApt = c.DateTime(storeType: "date"),
                        FecEnv = c.DateTime(storeType: "date"),
                        Coment = c.String(maxLength: 100),
                        Observ = c.String(maxLength: 100),
                        UserName = c.String(maxLength: 50),
                        IdAtenciones = c.Int(nullable: false),
                        IdMedico = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdMedicina)
                .ForeignKey("dbo.Atenciones", t => t.IdAtenciones, cascadeDelete: true)
                .ForeignKey("dbo.Medicos", t => t.IdMedico, cascadeDelete: true)
                .Index(t => t.IdAtenciones)
                .Index(t => t.IdMedico);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Medicinas", "IdMedico", "dbo.Medicos");
            DropForeignKey("dbo.Medicinas", "IdAtenciones", "dbo.Atenciones");
            DropIndex("dbo.Medicinas", new[] { "IdMedico" });
            DropIndex("dbo.Medicinas", new[] { "IdAtenciones" });
            DropTable("dbo.Medicinas");
            DropTable("dbo.Atenciones");
        }
    }
}
