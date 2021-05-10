namespace SG_ASP_2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Apti : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Aptituds",
                c => new
                    {
                        IdApti = c.Int(nullable: false, identity: true),
                        Descri = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.IdApti);
            
            AddColumn("dbo.Medicinas", "IdApti", c => c.Int(nullable: false));
            CreateIndex("dbo.Medicinas", "IdApti");
            AddForeignKey("dbo.Medicinas", "IdApti", "dbo.Aptituds", "IdApti", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Medicinas", "IdApti", "dbo.Aptituds");
            DropIndex("dbo.Medicinas", new[] { "IdApti" });
            DropColumn("dbo.Medicinas", "IdApti");
            DropTable("dbo.Aptituds");
        }
    }
}
