namespace Madison.Internal.QM.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class endorsement_selected : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Endorsement", "Selected", c => c.Boolean(nullable: false));
            DropColumn("dbo.Endorsement", "DefaultSelect");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Endorsement", "DefaultSelect", c => c.Boolean(nullable: false));
            DropColumn("dbo.Endorsement", "Selected");
        }
    }
}
