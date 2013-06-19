namespace Madison.Internal.QM.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class late : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Transaction", "BuyerPriorLenderPolicyDate", c => c.DateTime());
            AlterColumn("dbo.Transaction", "BuyerPriorLenderPolicyAmount", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Transaction", "BuyerUnpaidBalanceOfPriorLoan", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Transaction", "BuyerPriorOwnerPolicyDate", c => c.DateTime());
            AlterColumn("dbo.Transaction", "BuyerPriorOwnerPolicyAmount", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Transaction", "BuyerUnpaidBalance", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Transaction", "SellerPriorLenderPolicyDate", c => c.DateTime());
            AlterColumn("dbo.Transaction", "SellerPriorLenderPolicyAmount", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Transaction", "SellerUnpaidBalanceOfPriorLoan", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Transaction", "SellerPriorOwnerPolicyDate", c => c.DateTime());
            AlterColumn("dbo.Transaction", "SellerPriorOwnerPolicyAmount", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Transaction", "SellerUnpaidBalance", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Transaction", "SellerUnpaidBalance", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Transaction", "SellerPriorOwnerPolicyAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Transaction", "SellerPriorOwnerPolicyDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Transaction", "SellerUnpaidBalanceOfPriorLoan", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Transaction", "SellerPriorLenderPolicyAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Transaction", "SellerPriorLenderPolicyDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Transaction", "BuyerUnpaidBalance", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Transaction", "BuyerPriorOwnerPolicyAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Transaction", "BuyerPriorOwnerPolicyDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Transaction", "BuyerUnpaidBalanceOfPriorLoan", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Transaction", "BuyerPriorLenderPolicyAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Transaction", "BuyerPriorLenderPolicyDate", c => c.DateTime(nullable: false));
        }
    }
}
