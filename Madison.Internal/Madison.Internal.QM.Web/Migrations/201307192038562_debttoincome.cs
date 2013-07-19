namespace Madison.Internal.QM.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class debttoincome : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DebtIncome",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MonthlyIncome = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ExpectedMonthlyPayment = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RequiresPMI = c.Boolean(nullable: false),
                        ExpectedMonthlyPMI = c.Decimal(precision: 18, scale: 2),
                        AdditionalLoansOnProperty = c.Boolean(nullable: false),
                        TotalMontlyPaymentOfAdditionalLoans = c.Decimal(precision: 18, scale: 2),
                        MonthlyDebtObligation = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EmploymentLengthId = c.Int(nullable: false),
                        EmploymentStatusId = c.Int(nullable: false),
                        EmploymentLengthAtPriorCompanyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EmploymentStatus", t => t.EmploymentStatusId, cascadeDelete: true)
                .ForeignKey("dbo.EmploymentLength", t => t.EmploymentLengthId, cascadeDelete: false)
                .ForeignKey("dbo.EmploymentLength", t => t.EmploymentLengthAtPriorCompanyId, cascadeDelete: false)
                .Index(t => t.EmploymentStatusId)
                .Index(t => t.EmploymentLengthId)
                .Index(t => t.EmploymentLengthAtPriorCompanyId);
            
            CreateTable(
                "dbo.EmploymentStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EmploymentLength",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.DebtIncome", new[] { "EmploymentLengthAtPriorCompanyId" });
            DropIndex("dbo.DebtIncome", new[] { "EmploymentLengthId" });
            DropIndex("dbo.DebtIncome", new[] { "EmploymentStatusId" });
            DropForeignKey("dbo.DebtIncome", "EmploymentLengthAtPriorCompanyId", "dbo.EmploymentLength");
            DropForeignKey("dbo.DebtIncome", "EmploymentLengthId", "dbo.EmploymentLength");
            DropForeignKey("dbo.DebtIncome", "EmploymentStatusId", "dbo.EmploymentStatus");
            DropTable("dbo.EmploymentLength");
            DropTable("dbo.EmploymentStatus");
            DropTable("dbo.DebtIncome");
        }
    }
}
