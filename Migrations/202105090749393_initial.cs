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
                        Id = c.Int(nullable: false, identity: true),
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
                        Medico = c.Int(nullable: false),
                        Medicos_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Medicos", t => t.Medicos_Id)
                .Index(t => t.Medicos_Id);
            
            CreateTable(
                "dbo.Medicinas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AtenId = c.Int(nullable: false),
                        HorIng = c.Time(precision: 7),
                        HorSal = c.Time(precision: 7),
                        Medico = c.Int(nullable: false),
                        Aptitu = c.String(maxLength: 50),
                        FecApt = c.DateTime(storeType: "date"),
                        FecEnv = c.DateTime(storeType: "date"),
                        Coment = c.String(maxLength: 100),
                        Observ = c.String(maxLength: 100),
                        UserName = c.String(maxLength: 50),
                        Atenciones_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Atenciones", t => t.Atenciones_Id)
                .Index(t => t.Atenciones_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Atenciones", "Medicos_Id", "dbo.Medicos");
            DropForeignKey("dbo.Medicinas", "Atenciones_Id", "dbo.Atenciones");
            DropIndex("dbo.Medicinas", new[] { "Atenciones_Id" });
            DropIndex("dbo.Atenciones", new[] { "Medicos_Id" });
            DropTable("dbo.Medicinas");
            DropTable("dbo.Atenciones");
        }
    }
}
