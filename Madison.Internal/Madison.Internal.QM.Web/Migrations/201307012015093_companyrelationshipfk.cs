namespace Madison.Internal.QM.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class companyrelationshipfk : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserProfile", "CompanyRelationship_Id", "dbo.CompanyRelationship");
            DropIndex("dbo.UserProfile", new[] { "CompanyRelationship_Id" });
            RenameColumn(table: "dbo.UserProfile", name: "CompanyRelationship_Id", newName: "CompanyRelationshipId");
            AddForeignKey("dbo.UserProfile", "CompanyRelationshipId", "dbo.CompanyRelationship", "Id", cascadeDelete: true);
            CreateIndex("dbo.UserProfile", "CompanyRelationshipId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.UserProfile", new[] { "CompanyRelationshipId" });
            DropForeignKey("dbo.UserProfile", "CompanyRelationshipId", "dbo.CompanyRelationship");
            RenameColumn(table: "dbo.UserProfile", name: "CompanyRelationshipId", newName: "CompanyRelationship_Id");
            CreateIndex("dbo.UserProfile", "CompanyRelationship_Id");
            AddForeignKey("dbo.UserProfile", "CompanyRelationship_Id", "dbo.CompanyRelationship", "Id");
        }
    }
}
