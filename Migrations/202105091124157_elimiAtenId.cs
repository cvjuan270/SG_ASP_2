namespace SG_ASP_2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class elimiAtenId : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Medicinas", "AtenId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Medicinas", "AtenId", c => c.Int(nullable: false));
        }
    }
}
