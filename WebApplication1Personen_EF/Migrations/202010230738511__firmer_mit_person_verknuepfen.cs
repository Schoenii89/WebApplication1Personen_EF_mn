namespace WebApplication1Personen_EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _firmer_mit_person_verknuepfen : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Personens", "Firma_Id", c => c.Int());
            CreateIndex("dbo.Personens", "Firma_Id");
            AddForeignKey("dbo.Personens", "Firma_Id", "dbo.Firmen", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Personens", "Firma_Id", "dbo.Firmen");
            DropIndex("dbo.Personens", new[] { "Firma_Id" });
            DropColumn("dbo.Personens", "Firma_Id");
        }
    }
}
