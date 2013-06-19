namespace Madison.Internal.QM.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class policyproof : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transaction", "BuyerPriorOwnerPolicyAvailableAsProof", c => c.Boolean(nullable: false));
            AddColumn("dbo.Transaction", "SellerPriorOwnersPolicyAvailableAsProof", c => c.Boolean(nullable: false));
            DropColumn("dbo.Transaction", "PriorOwnersPolicyAvailableAsProof");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Transaction", "PriorOwnersPolicyAvailableAsProof", c => c.Boolean(nullable: false));
            DropColumn("dbo.Transaction", "SellerPriorOwnersPolicyAvailableAsProof");
            DropColumn("dbo.Transaction", "BuyerPriorOwnerPolicyAvailableAsProof");
        }
    }
}
