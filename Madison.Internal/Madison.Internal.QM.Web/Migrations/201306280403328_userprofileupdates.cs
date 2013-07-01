namespace Madison.Internal.QM.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userprofileupdates : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserProfile", "CompanyRelationship_Id", c => c.Int());
            AddForeignKey("dbo.UserProfile", "CompanyRelationship_Id", "dbo.CompanyRelationship", "Id");
            CreateIndex("dbo.UserProfile", "CompanyRelationship_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.UserProfile", new[] { "CompanyRelationship_Id" });
            DropForeignKey("dbo.UserProfile", "CompanyRelationship_Id", "dbo.CompanyRelationship");
            DropColumn("dbo.UserProfile", "CompanyRelationship_Id");
        }
    }
}
