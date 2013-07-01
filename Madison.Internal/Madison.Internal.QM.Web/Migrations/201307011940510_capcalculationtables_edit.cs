namespace Madison.Internal.QM.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class capcalculationtables_edit : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CapCalculationResult", "AffiliatedFeesResult_Id", "dbo.CapCalculationInitial");
            DropForeignKey("dbo.CapCalculationResult", "PriorFeesResult_Id", "dbo.CapCalculationResultFinals");
            DropIndex("dbo.CapCalculationResult", new[] { "AffiliatedFeesResult_Id" });
            DropIndex("dbo.CapCalculationResult", new[] { "PriorFeesResult_Id" });
            AddColumn("dbo.CapCalculationResult", "CapCalculationResultInitial_Id", c => c.Int());
            AddColumn("dbo.CapCalculationResult", "CapCalculationResultFinal_Id", c => c.Int());
            AddForeignKey("dbo.CapCalculationResult", "CapCalculationResultInitial_Id", "dbo.CapCalculationInitial", "Id");
            AddForeignKey("dbo.CapCalculationResult", "CapCalculationResultFinal_Id", "dbo.CapCalculationResultFinals", "Id");
            CreateIndex("dbo.CapCalculationResult", "CapCalculationResultInitial_Id");
            CreateIndex("dbo.CapCalculationResult", "CapCalculationResultFinal_Id");
            DropColumn("dbo.CapCalculationResult", "TransactionId");
            DropColumn("dbo.CapCalculationResult", "AffiliatedFeesResult_Id");
            DropColumn("dbo.CapCalculationResult", "PriorFeesResult_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CapCalculationResult", "PriorFeesResult_Id", c => c.Int());
            AddColumn("dbo.CapCalculationResult", "AffiliatedFeesResult_Id", c => c.Int());
            AddColumn("dbo.CapCalculationResult", "TransactionId", c => c.Int(nullable: false));
            DropIndex("dbo.CapCalculationResult", new[] { "CapCalculationResultFinal_Id" });
            DropIndex("dbo.CapCalculationResult", new[] { "CapCalculationResultInitial_Id" });
            DropForeignKey("dbo.CapCalculationResult", "CapCalculationResultFinal_Id", "dbo.CapCalculationResultFinals");
            DropForeignKey("dbo.CapCalculationResult", "CapCalculationResultInitial_Id", "dbo.CapCalculationInitial");
            DropColumn("dbo.CapCalculationResult", "CapCalculationResultFinal_Id");
            DropColumn("dbo.CapCalculationResult", "CapCalculationResultInitial_Id");
            CreateIndex("dbo.CapCalculationResult", "PriorFeesResult_Id");
            CreateIndex("dbo.CapCalculationResult", "AffiliatedFeesResult_Id");
            AddForeignKey("dbo.CapCalculationResult", "PriorFeesResult_Id", "dbo.CapCalculationResultFinals", "Id");
            AddForeignKey("dbo.CapCalculationResult", "AffiliatedFeesResult_Id", "dbo.CapCalculationInitial", "Id");
        }
    }
}
