namespace Madison.Internal.QM.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class capcalcedits : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.CapCalculationResultFinals", newName: "CapCalculationResultFinal");
            DropForeignKey("dbo.CapCalculationResult", "CapCalculationResultInitialId", "dbo.CapCalculationInitial");
            DropForeignKey("dbo.CapCalculationResult", "CapCalculationResultFinalId", "dbo.CapCalculationResultFinals");
            DropIndex("dbo.CapCalculationResult", new[] { "CapCalculationResultInitialId" });
            DropIndex("dbo.CapCalculationResult", new[] { "CapCalculationResultFinalId" });
            AlterColumn("dbo.CapCalculationResult", "CapCalculationResultInitialId", c => c.Int());
            AlterColumn("dbo.CapCalculationResult", "CapCalculationResultFinalId", c => c.Int());
            AddForeignKey("dbo.CapCalculationResult", "CapCalculationResultInitialId", "dbo.CapCalculationInitial", "Id");
            AddForeignKey("dbo.CapCalculationResult", "CapCalculationResultFinalId", "dbo.CapCalculationResultFinal", "Id");
            CreateIndex("dbo.CapCalculationResult", "CapCalculationResultInitialId");
            CreateIndex("dbo.CapCalculationResult", "CapCalculationResultFinalId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.CapCalculationResult", new[] { "CapCalculationResultFinalId" });
            DropIndex("dbo.CapCalculationResult", new[] { "CapCalculationResultInitialId" });
            DropForeignKey("dbo.CapCalculationResult", "CapCalculationResultFinalId", "dbo.CapCalculationResultFinal");
            DropForeignKey("dbo.CapCalculationResult", "CapCalculationResultInitialId", "dbo.CapCalculationInitial");
            AlterColumn("dbo.CapCalculationResult", "CapCalculationResultFinalId", c => c.Int(nullable: false));
            AlterColumn("dbo.CapCalculationResult", "CapCalculationResultInitialId", c => c.Int(nullable: false));
            CreateIndex("dbo.CapCalculationResult", "CapCalculationResultFinalId");
            CreateIndex("dbo.CapCalculationResult", "CapCalculationResultInitialId");
            AddForeignKey("dbo.CapCalculationResult", "CapCalculationResultFinalId", "dbo.CapCalculationResultFinals", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CapCalculationResult", "CapCalculationResultInitialId", "dbo.CapCalculationInitial", "Id", cascadeDelete: true);
            RenameTable(name: "dbo.CapCalculationResultFinal", newName: "CapCalculationResultFinals");
        }
    }
}
