namespace Madison.Internal.QM.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class transactiontype_reswarefields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TransactionType", "ResWareTransactionTypeId", c => c.Int(nullable: false, defaultValue: 1));
            AddColumn("dbo.TransactionType", "ResWareProductTypeId", c => c.Int(nullable: false, defaultValue: 1));
            DropColumn("dbo.LoanType", "ResWareTransactionTypeId");
            DropColumn("dbo.LoanType", "ResWareProductTypeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LoanType", "ResWareProductTypeId", c => c.Int(nullable: false));
            AddColumn("dbo.LoanType", "ResWareTransactionTypeId", c => c.Int(nullable: false));
            DropColumn("dbo.TransactionType", "ResWareProductTypeId");
            DropColumn("dbo.TransactionType", "ResWareTransactionTypeId");
        }
    }
}
