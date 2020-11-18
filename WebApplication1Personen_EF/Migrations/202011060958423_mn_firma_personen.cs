namespace WebApplication1Personen_EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mn_firma_personen : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Personens", "Firma_Id", "dbo.Firmen");
            DropIndex("dbo.Personens", new[] { "Firma_Id" });
            CreateTable(
                "dbo.PersonenFirmen",
                c => new
                    {
                        Personen_Id = c.Int(nullable: false),
                        Firmen_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Personen_Id, t.Firmen_Id })
                .ForeignKey("dbo.Personens", t => t.Personen_Id, cascadeDelete: true)
                .ForeignKey("dbo.Firmen", t => t.Firmen_Id, cascadeDelete: true)
                .Index(t => t.Personen_Id)
                .Index(t => t.Firmen_Id);
            
            DropColumn("dbo.Personens", "Firma_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Personens", "Firma_Id", c => c.Int());
            DropForeignKey("dbo.PersonenFirmen", "Firmen_Id", "dbo.Firmen");
            DropForeignKey("dbo.PersonenFirmen", "Personen_Id", "dbo.Personens");
            DropIndex("dbo.PersonenFirmen", new[] { "Firmen_Id" });
            DropIndex("dbo.PersonenFirmen", new[] { "Personen_Id" });
            DropTable("dbo.PersonenFirmen");
            CreateIndex("dbo.Personens", "Firma_Id");
            AddForeignKey("dbo.Personens", "Firma_Id", "dbo.Firmen", "Id");
        }
    }
}
