namespace Madison.Internal.QM.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class transactionmodelvalidation : DbMigration
    {
        public override void Up()
        {
            //AlterColumn("dbo.Transaction", "OriginalDebtAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            //AlterColumn("dbo.Transaction", "SalePrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            //AlterColumn("dbo.Transaction", "UnpaidPrincipalAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));

            AlterColumn("dbo.Transaction", "UnpaidPrincipalAmount", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Transaction", "SalePrice", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Transaction", "OriginalDebtAmount", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Transaction", "UnpaidPrincipalAmount", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Transaction", "SalePrice", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Transaction", "OriginalDebtAmount", c => c.Decimal(precision: 18, scale: 2));
        }
    }
}
