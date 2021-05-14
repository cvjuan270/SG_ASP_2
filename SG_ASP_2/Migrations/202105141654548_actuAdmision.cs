namespace SG_ASP_2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class actuAdmision : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admisions",
                c => new
                    {
                        IdAdmi = c.Int(nullable: false, identity: true),
                        IdAtenciones = c.Int(nullable: false),
                        HorIng = c.Time(precision: 7),
                        HorSal = c.Time(precision: 7),
                        Pendie = c.String(maxLength: 200),
                        UserName = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.IdAdmi)
                .ForeignKey("dbo.Atenciones", t => t.IdAtenciones, cascadeDelete: true)
                .Index(t => t.IdAtenciones);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Admisions", "IdAtenciones", "dbo.Atenciones");
            DropIndex("dbo.Admisions", new[] { "IdAtenciones" });
            DropTable("dbo.Admisions");
        }
    }
}
