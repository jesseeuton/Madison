namespace Madison.Internal.QM.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Transaction",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LoanAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PriorLenderPolicyDate = c.DateTime(nullable: false),
                        PriorLenderPolicyAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UnpaidBalanceOfPriorLoan = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PriorOwnerPolicyDate = c.DateTime(nullable: false),
                        PriorOwnerPolicyAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UnpaidBalance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TransactionType_Id = c.Int(),
                        LoanType_Id = c.Int(),
                        PropertyType_Id = c.Int(),
                        InterestType_Id = c.Int(),
                        Property_Id = c.Int(),
                        Person_Id = c.Int(),
                        Borrower_Id = c.Int(),
                        AffiliatedFee_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TransactionType", t => t.TransactionType_Id)
                .ForeignKey("dbo.LoanType", t => t.LoanType_Id)
                .ForeignKey("dbo.PropertyType", t => t.PropertyType_Id)
                .ForeignKey("dbo.InterestType", t => t.InterestType_Id)
                .ForeignKey("dbo.Property", t => t.Property_Id)
                .ForeignKey("dbo.Person", t => t.Person_Id)
                .ForeignKey("dbo.Borrower", t => t.Borrower_Id)
                .ForeignKey("dbo.AffiliatedFee", t => t.AffiliatedFee_Id)
                .Index(t => t.TransactionType_Id)
                .Index(t => t.LoanType_Id)
                .Index(t => t.PropertyType_Id)
                .Index(t => t.InterestType_Id)
                .Index(t => t.Property_Id)
                .Index(t => t.Person_Id)
                .Index(t => t.Borrower_Id)
                .Index(t => t.AffiliatedFee_Id);
            
            CreateTable(
                "dbo.TransactionType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LoanType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PropertyType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.InterestType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Property",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Address1 = c.String(nullable: false),
                        Address2 = c.String(),
                        City = c.String(nullable: false),
                        County = c.String(nullable: false),
                        State = c.String(nullable: false),
                        Zip = c.String(nullable: false),
                        PropertyType_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PropertyType", t => t.PropertyType_Id, cascadeDelete: true)
                .Index(t => t.PropertyType_Id);
            
            CreateTable(
                "dbo.Person",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        CompanyName = c.String(nullable: false),
                        EmailAddress = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        Relationship_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CompanyRelationship", t => t.Relationship_Id, cascadeDelete: true)
                .Index(t => t.Relationship_Id);
            
            CreateTable(
                "dbo.CompanyRelationship",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Borrower",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AffiliatedFee",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TotalSettlementFeeAppliedByAffiliate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AppraisalFeeAffiliated = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreditFeeIfAffiliated = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ThirdPartyOriginationFeePercent = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LenderFeesTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SurveyFeeAffiliated = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NotaryFeeAffiliated = c.Decimal(nullable: false, precision: 18, scale: 2),
                        InspectionFeeAffiliated = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Endorsement",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DefaultSelect = c.Boolean(nullable: false),
                        Transaction_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Transaction", t => t.Transaction_Id)
                .Index(t => t.Transaction_Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Endorsement", new[] { "Transaction_Id" });
            DropIndex("dbo.Person", new[] { "Relationship_Id" });
            DropIndex("dbo.Property", new[] { "PropertyType_Id" });
            DropIndex("dbo.Transaction", new[] { "AffiliatedFee_Id" });
            DropIndex("dbo.Transaction", new[] { "Borrower_Id" });
            DropIndex("dbo.Transaction", new[] { "Person_Id" });
            DropIndex("dbo.Transaction", new[] { "Property_Id" });
            DropIndex("dbo.Transaction", new[] { "InterestType_Id" });
            DropIndex("dbo.Transaction", new[] { "PropertyType_Id" });
            DropIndex("dbo.Transaction", new[] { "LoanType_Id" });
            DropIndex("dbo.Transaction", new[] { "TransactionType_Id" });
            DropForeignKey("dbo.Endorsement", "Transaction_Id", "dbo.Transaction");
            DropForeignKey("dbo.Person", "Relationship_Id", "dbo.CompanyRelationship");
            DropForeignKey("dbo.Property", "PropertyType_Id", "dbo.PropertyType");
            DropForeignKey("dbo.Transaction", "AffiliatedFee_Id", "dbo.AffiliatedFee");
            DropForeignKey("dbo.Transaction", "Borrower_Id", "dbo.Borrower");
            DropForeignKey("dbo.Transaction", "Person_Id", "dbo.Person");
            DropForeignKey("dbo.Transaction", "Property_Id", "dbo.Property");
            DropForeignKey("dbo.Transaction", "InterestType_Id", "dbo.InterestType");
            DropForeignKey("dbo.Transaction", "PropertyType_Id", "dbo.PropertyType");
            DropForeignKey("dbo.Transaction", "LoanType_Id", "dbo.LoanType");
            DropForeignKey("dbo.Transaction", "TransactionType_Id", "dbo.TransactionType");
            DropTable("dbo.Endorsement");
            DropTable("dbo.AffiliatedFee");
            DropTable("dbo.Borrower");
            DropTable("dbo.CompanyRelationship");
            DropTable("dbo.Person");
            DropTable("dbo.Property");
            DropTable("dbo.InterestType");
            DropTable("dbo.PropertyType");
            DropTable("dbo.LoanType");
            DropTable("dbo.TransactionType");
            DropTable("dbo.Transaction");
        }
    }
}
