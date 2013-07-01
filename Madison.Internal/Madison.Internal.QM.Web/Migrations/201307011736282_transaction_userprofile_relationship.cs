namespace Madison.Internal.QM.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class transaction_userprofile_relationship : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Transaction", "Person_Id", "dbo.Person");
            DropIndex("dbo.Transaction", new[] { "Person_Id" });
            AddColumn("dbo.Transaction", "UserProfile_UserId", c => c.Int());
            AddForeignKey("dbo.Transaction", "UserProfile_UserId", "dbo.UserProfile", "UserId");
            CreateIndex("dbo.Transaction", "UserProfile_UserId");
            DropColumn("dbo.Transaction", "Person_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Transaction", "Person_Id", c => c.Int());
            DropIndex("dbo.Transaction", new[] { "UserProfile_UserId" });
            DropForeignKey("dbo.Transaction", "UserProfile_UserId", "dbo.UserProfile");
            DropColumn("dbo.Transaction", "UserProfile_UserId");
            CreateIndex("dbo.Transaction", "Person_Id");
            AddForeignKey("dbo.Transaction", "Person_Id", "dbo.Person", "Id");
        }
    }
}
