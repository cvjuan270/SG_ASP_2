namespace SG_ASP_2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class afinando : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Medicos", "Medicina_Id", c => c.Int());
            CreateIndex("dbo.Medicos", "Medicina_Id");
            AddForeignKey("dbo.Medicos", "Medicina_Id", "dbo.Medicinas", "Id");
            DropColumn("dbo.Medicinas", "Medico");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Medicinas", "Medico", c => c.Int(nullable: false));
            DropForeignKey("dbo.Medicos", "Medicina_Id", "dbo.Medicinas");
            DropIndex("dbo.Medicos", new[] { "Medicina_Id" });
            DropColumn("dbo.Medicos", "Medicina_Id");
        }
    }
}
