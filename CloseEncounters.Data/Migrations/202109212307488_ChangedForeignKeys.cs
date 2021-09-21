namespace CloseEncounters.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedForeignKeys : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Encounter", "CreatureId", "dbo.Creature");
            DropForeignKey("dbo.Encounter", "LocationId", "dbo.Location");
            DropIndex("dbo.Encounter", new[] { "CreatureId" });
            DropIndex("dbo.Encounter", new[] { "LocationId" });
            AlterColumn("dbo.Encounter", "CreatureId", c => c.Int());
            AlterColumn("dbo.Encounter", "LocationId", c => c.Int());
            CreateIndex("dbo.Encounter", "CreatureId");
            CreateIndex("dbo.Encounter", "LocationId");
            AddForeignKey("dbo.Encounter", "CreatureId", "dbo.Creature", "CreatureId");
            AddForeignKey("dbo.Encounter", "LocationId", "dbo.Location", "LocationId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Encounter", "LocationId", "dbo.Location");
            DropForeignKey("dbo.Encounter", "CreatureId", "dbo.Creature");
            DropIndex("dbo.Encounter", new[] { "LocationId" });
            DropIndex("dbo.Encounter", new[] { "CreatureId" });
            AlterColumn("dbo.Encounter", "LocationId", c => c.Int(nullable: false));
            AlterColumn("dbo.Encounter", "CreatureId", c => c.Int(nullable: false));
            CreateIndex("dbo.Encounter", "LocationId");
            CreateIndex("dbo.Encounter", "CreatureId");
            AddForeignKey("dbo.Encounter", "LocationId", "dbo.Location", "LocationId", cascadeDelete: true);
            AddForeignKey("dbo.Encounter", "CreatureId", "dbo.Creature", "CreatureId", cascadeDelete: true);
        }
    }
}
