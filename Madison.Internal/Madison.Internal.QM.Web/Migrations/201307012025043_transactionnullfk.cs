namespace Madison.Internal.QM.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class transactionnullfk : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Transaction", "TransactionTypeId", "dbo.TransactionType");
            DropForeignKey("dbo.Transaction", "LoanTypeId", "dbo.LoanType");
            DropForeignKey("dbo.Transaction", "InterestTypeId", "dbo.InterestType");
            DropForeignKey("dbo.Transaction", "PropertyId", "dbo.Property");
            DropForeignKey("dbo.Transaction", "UserProfileId", "dbo.UserProfile");
            DropForeignKey("dbo.Transaction", "BorrowerId", "dbo.Borrower");
            DropForeignKey("dbo.Transaction", "FeeEstimateResultId", "dbo.FeeEstimateResult");
            DropForeignKey("dbo.Transaction", "CapCalculationResultId", "dbo.CapCalculationResult");
            DropIndex("dbo.Transaction", new[] { "TransactionTypeId" });
            DropIndex("dbo.Transaction", new[] { "LoanTypeId" });
            DropIndex("dbo.Transaction", new[] { "InterestTypeId" });
            DropIndex("dbo.Transaction", new[] { "PropertyId" });
            DropIndex("dbo.Transaction", new[] { "UserProfileId" });
            DropIndex("dbo.Transaction", new[] { "BorrowerId" });
            DropIndex("dbo.Transaction", new[] { "FeeEstimateResultId" });
            DropIndex("dbo.Transaction", new[] { "CapCalculationResultId" });
            AlterColumn("dbo.Transaction", "TransactionTypeId", c => c.Int());
            AlterColumn("dbo.Transaction", "LoanTypeId", c => c.Int());
            AlterColumn("dbo.Transaction", "InterestTypeId", c => c.Int());
            AlterColumn("dbo.Transaction", "PropertyId", c => c.Int());
            AlterColumn("dbo.Transaction", "UserProfileId", c => c.Int());
            AlterColumn("dbo.Transaction", "BorrowerId", c => c.Int());
            AlterColumn("dbo.Transaction", "FeeEstimateResultId", c => c.Int());
            AlterColumn("dbo.Transaction", "CapCalculationResultId", c => c.Int());
            AddForeignKey("dbo.Transaction", "TransactionTypeId", "dbo.TransactionType", "Id");
            AddForeignKey("dbo.Transaction", "LoanTypeId", "dbo.LoanType", "Id");
            AddForeignKey("dbo.Transaction", "InterestTypeId", "dbo.InterestType", "Id");
            AddForeignKey("dbo.Transaction", "PropertyId", "dbo.Property", "Id");
            AddForeignKey("dbo.Transaction", "UserProfileId", "dbo.UserProfile", "UserId");
            AddForeignKey("dbo.Transaction", "BorrowerId", "dbo.Borrower", "Id");
            AddForeignKey("dbo.Transaction", "FeeEstimateResultId", "dbo.FeeEstimateResult", "Id");
            AddForeignKey("dbo.Transaction", "CapCalculationResultId", "dbo.CapCalculationResult", "Id");
            CreateIndex("dbo.Transaction", "TransactionTypeId");
            CreateIndex("dbo.Transaction", "LoanTypeId");
            CreateIndex("dbo.Transaction", "InterestTypeId");
            CreateIndex("dbo.Transaction", "PropertyId");
            CreateIndex("dbo.Transaction", "UserProfileId");
            CreateIndex("dbo.Transaction", "BorrowerId");
            CreateIndex("dbo.Transaction", "FeeEstimateResultId");
            CreateIndex("dbo.Transaction", "CapCalculationResultId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Transaction", new[] { "CapCalculationResultId" });
            DropIndex("dbo.Transaction", new[] { "FeeEstimateResultId" });
            DropIndex("dbo.Transaction", new[] { "BorrowerId" });
            DropIndex("dbo.Transaction", new[] { "UserProfileId" });
            DropIndex("dbo.Transaction", new[] { "PropertyId" });
            DropIndex("dbo.Transaction", new[] { "InterestTypeId" });
            DropIndex("dbo.Transaction", new[] { "LoanTypeId" });
            DropIndex("dbo.Transaction", new[] { "TransactionTypeId" });
            DropForeignKey("dbo.Transaction", "CapCalculationResultId", "dbo.CapCalculationResult");
            DropForeignKey("dbo.Transaction", "FeeEstimateResultId", "dbo.FeeEstimateResult");
            DropForeignKey("dbo.Transaction", "BorrowerId", "dbo.Borrower");
            DropForeignKey("dbo.Transaction", "UserProfileId", "dbo.UserProfile");
            DropForeignKey("dbo.Transaction", "PropertyId", "dbo.Property");
            DropForeignKey("dbo.Transaction", "InterestTypeId", "dbo.InterestType");
            DropForeignKey("dbo.Transaction", "LoanTypeId", "dbo.LoanType");
            DropForeignKey("dbo.Transaction", "TransactionTypeId", "dbo.TransactionType");
            AlterColumn("dbo.Transaction", "CapCalculationResultId", c => c.Int(nullable: false));
            AlterColumn("dbo.Transaction", "FeeEstimateResultId", c => c.Int(nullable: false));
            AlterColumn("dbo.Transaction", "BorrowerId", c => c.Int(nullable: false));
            AlterColumn("dbo.Transaction", "UserProfileId", c => c.Int(nullable: false));
            AlterColumn("dbo.Transaction", "PropertyId", c => c.Int(nullable: false));
            AlterColumn("dbo.Transaction", "InterestTypeId", c => c.Int(nullable: false));
            AlterColumn("dbo.Transaction", "LoanTypeId", c => c.Int(nullable: false));
            AlterColumn("dbo.Transaction", "TransactionTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Transaction", "CapCalculationResultId");
            CreateIndex("dbo.Transaction", "FeeEstimateResultId");
            CreateIndex("dbo.Transaction", "BorrowerId");
            CreateIndex("dbo.Transaction", "UserProfileId");
            CreateIndex("dbo.Transaction", "PropertyId");
            CreateIndex("dbo.Transaction", "InterestTypeId");
            CreateIndex("dbo.Transaction", "LoanTypeId");
            CreateIndex("dbo.Transaction", "TransactionTypeId");
            AddForeignKey("dbo.Transaction", "CapCalculationResultId", "dbo.CapCalculationResult", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Transaction", "FeeEstimateResultId", "dbo.FeeEstimateResult", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Transaction", "BorrowerId", "dbo.Borrower", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Transaction", "UserProfileId", "dbo.UserProfile", "UserId", cascadeDelete: true);
            AddForeignKey("dbo.Transaction", "PropertyId", "dbo.Property", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Transaction", "InterestTypeId", "dbo.InterestType", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Transaction", "LoanTypeId", "dbo.LoanType", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Transaction", "TransactionTypeId", "dbo.TransactionType", "Id", cascadeDelete: true);
        }
    }
}
