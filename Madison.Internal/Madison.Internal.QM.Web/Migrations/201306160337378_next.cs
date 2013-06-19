namespace Madison.Internal.QM.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class next : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AffiliatedFee", "TotalSettlementFee", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.AffiliatedFee", "AppraisalFee", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.AffiliatedFee", "CreditFee", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.AffiliatedFee", "MortageOriginatorCompensationAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.AffiliatedFee", "SurveyFee", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.AffiliatedFee", "NotaryFee", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.AffiliatedFee", "InspectionFee", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.AffiliatedFee", "TotalSettlementFeeAppliedByAffiliate");
            DropColumn("dbo.AffiliatedFee", "AppraisalFeeAffiliated");
            DropColumn("dbo.AffiliatedFee", "CreditFeeIfAffiliated");
            DropColumn("dbo.AffiliatedFee", "LenderFeesTotal");
            DropColumn("dbo.AffiliatedFee", "SurveyFeeAffiliated");
            DropColumn("dbo.AffiliatedFee", "NotaryFeeAffiliated");
            DropColumn("dbo.AffiliatedFee", "InspectionFeeAffiliated");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AffiliatedFee", "InspectionFeeAffiliated", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.AffiliatedFee", "NotaryFeeAffiliated", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.AffiliatedFee", "SurveyFeeAffiliated", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.AffiliatedFee", "LenderFeesTotal", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.AffiliatedFee", "CreditFeeIfAffiliated", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.AffiliatedFee", "AppraisalFeeAffiliated", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.AffiliatedFee", "TotalSettlementFeeAppliedByAffiliate", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.AffiliatedFee", "InspectionFee");
            DropColumn("dbo.AffiliatedFee", "NotaryFee");
            DropColumn("dbo.AffiliatedFee", "SurveyFee");
            DropColumn("dbo.AffiliatedFee", "MortageOriginatorCompensationAmount");
            DropColumn("dbo.AffiliatedFee", "CreditFee");
            DropColumn("dbo.AffiliatedFee", "AppraisalFee");
            DropColumn("dbo.AffiliatedFee", "TotalSettlementFee");
        }
    }
}
