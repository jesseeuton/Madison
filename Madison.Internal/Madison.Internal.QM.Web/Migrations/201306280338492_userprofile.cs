namespace Madison.Internal.QM.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userprofile : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserProfile",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        PartnerCompanyName = c.String(),
                        PartnerCompanyId = c.Int(nullable: false),
                        Email = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserProfile");
        }
    }
}
