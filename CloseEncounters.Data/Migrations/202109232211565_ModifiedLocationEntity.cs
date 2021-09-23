namespace CloseEncounters.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedLocationEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Location", "LocationName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Location", "LocationName");
        }
    }
}
