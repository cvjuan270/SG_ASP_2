namespace SG_ASP_2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class borracampoapti : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Medicinas", "Aptitu");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Medicinas", "Aptitu", c => c.String(maxLength: 50));
        }
    }
}
