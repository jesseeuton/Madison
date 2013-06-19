namespace Madison.Internal.QM.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class priorinfo_2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transaction", "SellerPriorOwnerPolicyAvailableAsProof", c => c.Boolean(nullable: false));
            DropColumn("dbo.Transaction", "SellerPriorOwnersPolicyAvailableAsProof");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Transaction", "SellerPriorOwnersPolicyAvailableAsProof", c => c.Boolean(nullable: false));
            DropColumn("dbo.Transaction", "SellerPriorOwnerPolicyAvailableAsProof");
        }
    }
}
