namespace WebApplication1Personen_EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Personens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Vorname = c.String(),
                        Nachname = c.String(),
                        Geburtstag = c.DateTime(nullable: false),
                        EmailAdr = c.String(),
                        TelNummer = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Personens");
        }
    }
}
