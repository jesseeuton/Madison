namespace Madison.Internal.QM.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class priorchanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transaction", "BuyerPriorLenderPolicyDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Transaction", "BuyerPriorLenderPolicyAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Transaction", "BuyerUnpaidBalanceOfPriorLoan", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Transaction", "BuyerPriorOwnerPolicyDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Transaction", "BuyerPriorOwnerPolicyAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Transaction", "BuyerUnpaidBalance", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Transaction", "BuyerPriorLenderPolicyAvailableAsProof", c => c.Boolean(nullable: false));
            AddColumn("dbo.Transaction", "SellerPriorLenderPolicyDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Transaction", "SellerPriorLenderPolicyAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Transaction", "SellerUnpaidBalanceOfPriorLoan", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Transaction", "SellerPriorOwnerPolicyDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Transaction", "SellerPriorOwnerPolicyAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Transaction", "SellerUnpaidBalance", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Transaction", "SellerPriorLenderPolicyAvailableAsProof", c => c.Boolean(nullable: false));
            DropColumn("dbo.Transaction", "PriorLenderPolicyDate");
            DropColumn("dbo.Transaction", "PriorLenderPolicyAmount");
            DropColumn("dbo.Transaction", "UnpaidBalanceOfPriorLoan");
            DropColumn("dbo.Transaction", "PriorOwnerPolicyDate");
            DropColumn("dbo.Transaction", "PriorOwnerPolicyAmount");
            DropColumn("dbo.Transaction", "UnpaidBalance");
            DropColumn("dbo.Transaction", "PriorLenderPolicyAvailableAsProof");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Transaction", "PriorLenderPolicyAvailableAsProof", c => c.Boolean(nullable: false));
            AddColumn("dbo.Transaction", "UnpaidBalance", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Transaction", "PriorOwnerPolicyAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Transaction", "PriorOwnerPolicyDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Transaction", "UnpaidBalanceOfPriorLoan", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Transaction", "PriorLenderPolicyAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Transaction", "PriorLenderPolicyDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Transaction", "SellerPriorLenderPolicyAvailableAsProof");
            DropColumn("dbo.Transaction", "SellerUnpaidBalance");
            DropColumn("dbo.Transaction", "SellerPriorOwnerPolicyAmount");
            DropColumn("dbo.Transaction", "SellerPriorOwnerPolicyDate");
            DropColumn("dbo.Transaction", "SellerUnpaidBalanceOfPriorLoan");
            DropColumn("dbo.Transaction", "SellerPriorLenderPolicyAmount");
            DropColumn("dbo.Transaction", "SellerPriorLenderPolicyDate");
            DropColumn("dbo.Transaction", "BuyerPriorLenderPolicyAvailableAsProof");
            DropColumn("dbo.Transaction", "BuyerUnpaidBalance");
            DropColumn("dbo.Transaction", "BuyerPriorOwnerPolicyAmount");
            DropColumn("dbo.Transaction", "BuyerPriorOwnerPolicyDate");
            DropColumn("dbo.Transaction", "BuyerUnpaidBalanceOfPriorLoan");
            DropColumn("dbo.Transaction", "BuyerPriorLenderPolicyAmount");
            DropColumn("dbo.Transaction", "BuyerPriorLenderPolicyDate");
        }
    }
}
