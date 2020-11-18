namespace WebApplication1Personen_EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pnnn41 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Personens", "Geburtsjahr", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Personens", "Geburtsjahr");
        }
    }
}
