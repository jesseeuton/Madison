namespace Madison.Internal.QM.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class transactionadditions : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transaction", "OriginalDebtAmount", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Transaction", "SalePrice", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Transaction", "UnpaidPrincipalAmount", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Transaction", "UnpaidPrincipalAmount");
            DropColumn("dbo.Transaction", "SalePrice");
            DropColumn("dbo.Transaction", "OriginalDebtAmount");
        }
    }
}
