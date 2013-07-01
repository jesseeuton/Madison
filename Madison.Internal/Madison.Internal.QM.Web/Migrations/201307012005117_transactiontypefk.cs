namespace Madison.Internal.QM.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class transactiontypefk : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Transaction", "TransactionType_Id", "dbo.TransactionType");
            DropForeignKey("dbo.Transaction", "LoanType_Id", "dbo.LoanType");
            DropIndex("dbo.Transaction", new[] { "TransactionType_Id" });
            DropIndex("dbo.Transaction", new[] { "LoanType_Id" });
            RenameColumn(table: "dbo.Transaction", name: "TransactionType_Id", newName: "TransactionTypeId");
            RenameColumn(table: "dbo.Transaction", name: "LoanType_Id", newName: "LoanTypeId");
            AddForeignKey("dbo.Transaction", "TransactionTypeId", "dbo.TransactionType", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Transaction", "LoanTypeId", "dbo.LoanType", "Id", cascadeDelete: true);
            CreateIndex("dbo.Transaction", "TransactionTypeId");
            CreateIndex("dbo.Transaction", "LoanTypeId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Transaction", new[] { "LoanTypeId" });
            DropIndex("dbo.Transaction", new[] { "TransactionTypeId" });
            DropForeignKey("dbo.Transaction", "LoanTypeId", "dbo.LoanType");
            DropForeignKey("dbo.Transaction", "TransactionTypeId", "dbo.TransactionType");
            RenameColumn(table: "dbo.Transaction", name: "LoanTypeId", newName: "LoanType_Id");
            RenameColumn(table: "dbo.Transaction", name: "TransactionTypeId", newName: "TransactionType_Id");
            CreateIndex("dbo.Transaction", "LoanType_Id");
            CreateIndex("dbo.Transaction", "TransactionType_Id");
            AddForeignKey("dbo.Transaction", "LoanType_Id", "dbo.LoanType", "Id");
            AddForeignKey("dbo.Transaction", "TransactionType_Id", "dbo.TransactionType", "Id");
        }
    }
}
