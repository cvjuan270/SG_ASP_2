namespace SG_ASP_2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addfechasadmin : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admisions", "HorReg", c => c.Time(precision: 7));
            AddColumn("dbo.Admisions", "EnvAsi", c => c.Boolean(nullable: false));
            AddColumn("dbo.Admisions", "EnvApt", c => c.Boolean(nullable: false));
            AddColumn("dbo.Admisions", "FecEnvResMed", c => c.DateTime(storeType: "date"));
            AddColumn("dbo.Admisions", "FecEnvResEmp", c => c.DateTime(storeType: "date"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Admisions", "FecEnvResEmp");
            DropColumn("dbo.Admisions", "FecEnvResMed");
            DropColumn("dbo.Admisions", "EnvApt");
            DropColumn("dbo.Admisions", "EnvAsi");
            DropColumn("dbo.Admisions", "HorReg");
        }
    }
}
