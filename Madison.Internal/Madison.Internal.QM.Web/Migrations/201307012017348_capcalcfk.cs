namespace Madison.Internal.QM.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class capcalcfk : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CapCalculationResult", "CapCalculationResultInitial_Id", "dbo.CapCalculationInitial");
            DropForeignKey("dbo.CapCalculationResult", "CapCalculationResultFinal_Id", "dbo.CapCalculationResultFinals");
            DropIndex("dbo.CapCalculationResult", new[] { "CapCalculationResultInitial_Id" });
            DropIndex("dbo.CapCalculationResult", new[] { "CapCalculationResultFinal_Id" });
            RenameColumn(table: "dbo.CapCalculationResult", name: "CapCalculationResultInitial_Id", newName: "CapCalculationResultInitialId");
            RenameColumn(table: "dbo.CapCalculationResult", name: "CapCalculationResultFinal_Id", newName: "CapCalculationResultFinalId");
            AddForeignKey("dbo.CapCalculationResult", "CapCalculationResultInitialId", "dbo.CapCalculationInitial", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CapCalculationResult", "CapCalculationResultFinalId", "dbo.CapCalculationResultFinals", "Id", cascadeDelete: true);
            CreateIndex("dbo.CapCalculationResult", "CapCalculationResultInitialId");
            CreateIndex("dbo.CapCalculationResult", "CapCalculationResultFinalId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.CapCalculationResult", new[] { "CapCalculationResultFinalId" });
            DropIndex("dbo.CapCalculationResult", new[] { "CapCalculationResultInitialId" });
            DropForeignKey("dbo.CapCalculationResult", "CapCalculationResultFinalId", "dbo.CapCalculationResultFinals");
            DropForeignKey("dbo.CapCalculationResult", "CapCalculationResultInitialId", "dbo.CapCalculationInitial");
            RenameColumn(table: "dbo.CapCalculationResult", name: "CapCalculationResultFinalId", newName: "CapCalculationResultFinal_Id");
            RenameColumn(table: "dbo.CapCalculationResult", name: "CapCalculationResultInitialId", newName: "CapCalculationResultInitial_Id");
            CreateIndex("dbo.CapCalculationResult", "CapCalculationResultFinal_Id");
            CreateIndex("dbo.CapCalculationResult", "CapCalculationResultInitial_Id");
            AddForeignKey("dbo.CapCalculationResult", "CapCalculationResultFinal_Id", "dbo.CapCalculationResultFinals", "Id");
            AddForeignKey("dbo.CapCalculationResult", "CapCalculationResultInitial_Id", "dbo.CapCalculationInitial", "Id");
        }
    }
}
