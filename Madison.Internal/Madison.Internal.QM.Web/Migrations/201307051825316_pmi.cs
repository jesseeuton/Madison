namespace Madison.Internal.QM.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pmi : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AffiliatedFees", "PMI", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AffiliatedFees", "PMI");
        }
    }
}
