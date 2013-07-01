namespace Madison.Internal.QM.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userprofile_officeid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserProfile", "OfficeId", c => c.Int(nullable: false, defaultValue: 1));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserProfile", "OfficeId");
        }
    }
}
