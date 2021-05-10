namespace SG_ASP_2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asdf : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Interconsultas",
                c => new
                    {
                        IdInter = c.Int(nullable: false, identity: true),
                        IdAtenciones = c.Int(nullable: false),
                        Descri = c.String(maxLength: 50),
                        FecEnv = c.DateTime(storeType: "date"),
                        PeEnCo = c.String(maxLength: 50),
                        EnHoIn = c.Boolean(nullable: false),
                        FeCoPa = c.DateTime(storeType: "date"),
                        PeCoPa = c.String(maxLength: 50),
                        FeLeObs = c.DateTime(storeType: "date"),
                        UserName = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.IdInter)
                .ForeignKey("dbo.Atenciones", t => t.IdAtenciones, cascadeDelete: true)
                .Index(t => t.IdAtenciones);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Interconsultas", "IdAtenciones", "dbo.Atenciones");
            DropIndex("dbo.Interconsultas", new[] { "IdAtenciones" });
            DropTable("dbo.Interconsultas");
        }
    }
}
