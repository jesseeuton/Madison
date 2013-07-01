namespace Madison.Internal.QM.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class propertyfk : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Transaction", "PropertyTypeId", "dbo.PropertyType");
            DropForeignKey("dbo.Transaction", "Property_Id", "dbo.Property");
            DropIndex("dbo.Transaction", new[] { "PropertyTypeId" });
            DropIndex("dbo.Transaction", new[] { "Property_Id" });
            RenameColumn(table: "dbo.Transaction", name: "Property_Id", newName: "PropertyId");
            RenameColumn(table: "dbo.Property", name: "PropertyType_Id", newName: "PropertyTypeId");
            AddForeignKey("dbo.Transaction", "PropertyId", "dbo.Property", "Id", cascadeDelete: true);
            CreateIndex("dbo.Transaction", "PropertyId");
            DropColumn("dbo.Transaction", "PropertyTypeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Transaction", "PropertyTypeId", c => c.Int(nullable: false));
            DropIndex("dbo.Transaction", new[] { "PropertyId" });
            DropForeignKey("dbo.Transaction", "PropertyId", "dbo.Property");
            RenameColumn(table: "dbo.Property", name: "PropertyTypeId", newName: "PropertyType_Id");
            RenameColumn(table: "dbo.Transaction", name: "PropertyId", newName: "Property_Id");
            CreateIndex("dbo.Transaction", "Property_Id");
            CreateIndex("dbo.Transaction", "PropertyTypeId");
            AddForeignKey("dbo.Transaction", "Property_Id", "dbo.Property", "Id");
            AddForeignKey("dbo.Transaction", "PropertyTypeId", "dbo.PropertyType", "Id", cascadeDelete: true);
        }
    }
}
