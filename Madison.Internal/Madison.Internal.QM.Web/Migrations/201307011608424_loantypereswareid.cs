namespace Madison.Internal.QM.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class loantypereswareid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LoanType", "ResWareTransactionTypeId", c => c.Int(nullable: false, defaultValue: 1));
            AddColumn("dbo.LoanType", "ResWareProductTypeId", c => c.Int(nullable: false, defaultValue: 1));
        }
        
        public override void Down()
        {
            DropColumn("dbo.LoanType", "ResWareProductTypeId");
            DropColumn("dbo.LoanType", "ResWareTransactionTypeId");
        }
    }
}
