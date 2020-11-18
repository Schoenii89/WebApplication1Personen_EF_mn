namespace WebApplication1Personen_EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1020_firmenHinzugefuegt : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Firmen",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        PLZ = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Firmen");
        }
    }
}
