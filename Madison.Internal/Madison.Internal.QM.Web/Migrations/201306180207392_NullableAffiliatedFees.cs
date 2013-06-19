namespace Madison.Internal.QM.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullableAffiliatedFees : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AffiliatedFees", "TotalSettlementFee", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.AffiliatedFees", "AppraisalFee", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.AffiliatedFees", "CreditFee", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.AffiliatedFees", "MortageOriginatorCompensationAmount", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.AffiliatedFees", "SurveyFee", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.AffiliatedFees", "NotaryFee", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.AffiliatedFees", "InspectionFee", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.AffiliatedFees", "LenderFee", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AffiliatedFees", "LenderFee", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.AffiliatedFees", "InspectionFee", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.AffiliatedFees", "NotaryFee", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.AffiliatedFees", "SurveyFee", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.AffiliatedFees", "MortageOriginatorCompensationAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.AffiliatedFees", "CreditFee", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.AffiliatedFees", "AppraisalFee", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.AffiliatedFees", "TotalSettlementFee", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
