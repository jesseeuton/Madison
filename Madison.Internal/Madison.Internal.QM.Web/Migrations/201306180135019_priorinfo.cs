namespace Madison.Internal.QM.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class priorinfo : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Transaction", "AffiliatedFee_Id", "dbo.AffiliatedFee");
            DropIndex("dbo.Transaction", new[] { "AffiliatedFee_Id" });
            CreateTable(
                "dbo.AffiliatedFees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TotalSettlementFee = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AppraisalFee = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreditFee = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MortageOriginatorCompensationAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SurveyFee = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NotaryFee = c.Decimal(nullable: false, precision: 18, scale: 2),
                        InspectionFee = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LenderFee = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            AddForeignKey("dbo.Transaction", "AffiliatedFee_Id", "dbo.AffiliatedFees", "Id");
            CreateIndex("dbo.Transaction", "AffiliatedFee_Id");
            DropTable("dbo.AffiliatedFee");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.AffiliatedFee",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TotalSettlementFee = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AppraisalFee = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreditFee = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MortageOriginatorCompensationAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SurveyFee = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NotaryFee = c.Decimal(nullable: false, precision: 18, scale: 2),
                        InspectionFee = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ThirdPartyOriginationFeePercent = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            DropIndex("dbo.Transaction", new[] { "AffiliatedFee_Id" });
            DropForeignKey("dbo.Transaction", "AffiliatedFee_Id", "dbo.AffiliatedFees");
            DropTable("dbo.AffiliatedFees");
            CreateIndex("dbo.Transaction", "AffiliatedFee_Id");
            AddForeignKey("dbo.Transaction", "AffiliatedFee_Id", "dbo.AffiliatedFee", "Id");
        }
    }
}
