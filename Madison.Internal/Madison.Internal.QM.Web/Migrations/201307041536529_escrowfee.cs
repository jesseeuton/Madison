namespace Madison.Internal.QM.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class escrowfee : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AffiliatedFees", "EscrowFee", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AffiliatedFees", "EscrowFee");
        }
    }
}
