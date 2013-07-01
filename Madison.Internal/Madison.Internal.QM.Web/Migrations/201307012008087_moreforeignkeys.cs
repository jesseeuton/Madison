namespace Madison.Internal.QM.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class moreforeignkeys : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Transaction", "PropertyType_Id", "dbo.PropertyType");
            DropForeignKey("dbo.Transaction", "InterestType_Id", "dbo.InterestType");
            DropForeignKey("dbo.Transaction", "UserProfile_UserId", "dbo.UserProfile");
            DropForeignKey("dbo.Transaction", "Borrower_Id", "dbo.Borrower");
            DropForeignKey("dbo.Transaction", "FeeEstimateResult_Id", "dbo.FeeEstimateResult");
            DropForeignKey("dbo.Transaction", "CapCalculationResult_Id", "dbo.CapCalculationResult");
            DropIndex("dbo.Transaction", new[] { "PropertyType_Id" });
            DropIndex("dbo.Transaction", new[] { "InterestType_Id" });
            DropIndex("dbo.Transaction", new[] { "UserProfile_UserId" });
            DropIndex("dbo.Transaction", new[] { "Borrower_Id" });
            DropIndex("dbo.Transaction", new[] { "FeeEstimateResult_Id" });
            DropIndex("dbo.Transaction", new[] { "CapCalculationResult_Id" });
            RenameColumn(table: "dbo.Transaction", name: "PropertyType_Id", newName: "PropertyTypeId");
            RenameColumn(table: "dbo.Transaction", name: "InterestType_Id", newName: "InterestTypeId");
            RenameColumn(table: "dbo.Transaction", name: "UserProfile_UserId", newName: "UserProfileId");
            RenameColumn(table: "dbo.Transaction", name: "Borrower_Id", newName: "BorrowerId");
            RenameColumn(table: "dbo.Transaction", name: "FeeEstimateResult_Id", newName: "FeeEstimateResultId");
            RenameColumn(table: "dbo.Transaction", name: "CapCalculationResult_Id", newName: "CapCalculationResultId");
            AddForeignKey("dbo.Transaction", "PropertyTypeId", "dbo.PropertyType", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Transaction", "InterestTypeId", "dbo.InterestType", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Transaction", "UserProfileId", "dbo.UserProfile", "UserId", cascadeDelete: true);
            AddForeignKey("dbo.Transaction", "BorrowerId", "dbo.Borrower", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Transaction", "FeeEstimateResultId", "dbo.FeeEstimateResult", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Transaction", "CapCalculationResultId", "dbo.CapCalculationResult", "Id", cascadeDelete: true);
            CreateIndex("dbo.Transaction", "PropertyTypeId");
            CreateIndex("dbo.Transaction", "InterestTypeId");
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
            DropIndex("dbo.Transaction", new[] { "InterestTypeId" });
            DropIndex("dbo.Transaction", new[] { "PropertyTypeId" });
            DropForeignKey("dbo.Transaction", "CapCalculationResultId", "dbo.CapCalculationResult");
            DropForeignKey("dbo.Transaction", "FeeEstimateResultId", "dbo.FeeEstimateResult");
            DropForeignKey("dbo.Transaction", "BorrowerId", "dbo.Borrower");
            DropForeignKey("dbo.Transaction", "UserProfileId", "dbo.UserProfile");
            DropForeignKey("dbo.Transaction", "InterestTypeId", "dbo.InterestType");
            DropForeignKey("dbo.Transaction", "PropertyTypeId", "dbo.PropertyType");
            RenameColumn(table: "dbo.Transaction", name: "CapCalculationResultId", newName: "CapCalculationResult_Id");
            RenameColumn(table: "dbo.Transaction", name: "FeeEstimateResultId", newName: "FeeEstimateResult_Id");
            RenameColumn(table: "dbo.Transaction", name: "BorrowerId", newName: "Borrower_Id");
            RenameColumn(table: "dbo.Transaction", name: "UserProfileId", newName: "UserProfile_UserId");
            RenameColumn(table: "dbo.Transaction", name: "InterestTypeId", newName: "InterestType_Id");
            RenameColumn(table: "dbo.Transaction", name: "PropertyTypeId", newName: "PropertyType_Id");
            CreateIndex("dbo.Transaction", "CapCalculationResult_Id");
            CreateIndex("dbo.Transaction", "FeeEstimateResult_Id");
            CreateIndex("dbo.Transaction", "Borrower_Id");
            CreateIndex("dbo.Transaction", "UserProfile_UserId");
            CreateIndex("dbo.Transaction", "InterestType_Id");
            CreateIndex("dbo.Transaction", "PropertyType_Id");
            AddForeignKey("dbo.Transaction", "CapCalculationResult_Id", "dbo.CapCalculationResult", "Id");
            AddForeignKey("dbo.Transaction", "FeeEstimateResult_Id", "dbo.FeeEstimateResult", "Id");
            AddForeignKey("dbo.Transaction", "Borrower_Id", "dbo.Borrower", "Id");
            AddForeignKey("dbo.Transaction", "UserProfile_UserId", "dbo.UserProfile", "UserId");
            AddForeignKey("dbo.Transaction", "InterestType_Id", "dbo.InterestType", "Id");
            AddForeignKey("dbo.Transaction", "PropertyType_Id", "dbo.PropertyType", "Id");
        }
    }
}
