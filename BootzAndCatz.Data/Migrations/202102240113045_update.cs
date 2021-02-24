namespace BootzAndCatz.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cat", "ShelterName", "dbo.Shelter");
            DropForeignKey("dbo.Dog", "ShelterName", "dbo.Shelter");
            DropIndex("dbo.Cat", new[] { "ShelterName" });
            DropIndex("dbo.Dog", new[] { "ShelterName" });
            RenameColumn(table: "dbo.Cat", name: "ShelterName", newName: "ShelterId");
            RenameColumn(table: "dbo.Dog", name: "ShelterName", newName: "ShelterId");
            DropPrimaryKey("dbo.Shelter");
            AddColumn("dbo.Shelter", "ShelterId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Cat", "ShelterId", c => c.Int(nullable: false));
            AlterColumn("dbo.Shelter", "ShelterName", c => c.String(nullable: false));
            AlterColumn("dbo.Dog", "ShelterId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Shelter", "ShelterId");
            CreateIndex("dbo.Cat", "ShelterId");
            CreateIndex("dbo.Dog", "ShelterId");
            AddForeignKey("dbo.Cat", "ShelterId", "dbo.Shelter", "ShelterId", cascadeDelete: true);
            AddForeignKey("dbo.Dog", "ShelterId", "dbo.Shelter", "ShelterId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Dog", "ShelterId", "dbo.Shelter");
            DropForeignKey("dbo.Cat", "ShelterId", "dbo.Shelter");
            DropIndex("dbo.Dog", new[] { "ShelterId" });
            DropIndex("dbo.Cat", new[] { "ShelterId" });
            DropPrimaryKey("dbo.Shelter");
            AlterColumn("dbo.Dog", "ShelterId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Shelter", "ShelterName", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Cat", "ShelterId", c => c.String(maxLength: 128));
            DropColumn("dbo.Shelter", "ShelterId");
            AddPrimaryKey("dbo.Shelter", "ShelterName");
            RenameColumn(table: "dbo.Dog", name: "ShelterId", newName: "ShelterName");
            RenameColumn(table: "dbo.Cat", name: "ShelterId", newName: "ShelterName");
            CreateIndex("dbo.Dog", "ShelterName");
            CreateIndex("dbo.Cat", "ShelterName");
            AddForeignKey("dbo.Dog", "ShelterName", "dbo.Shelter", "ShelterName");
            AddForeignKey("dbo.Cat", "ShelterName", "dbo.Shelter", "ShelterName");
        }
    }
}
