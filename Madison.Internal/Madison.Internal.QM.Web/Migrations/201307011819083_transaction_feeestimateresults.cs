namespace Madison.Internal.QM.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class transaction_feeestimateresults : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FeeEstimateResult",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WasSuccessful = c.Boolean(nullable: false),
                        Message = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Fee",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        HudLine = c.String(),
                        HudLineDescription = c.String(),
                        FeeEstimateResult_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FeeEstimateResult", t => t.FeeEstimateResult_Id)
                .Index(t => t.FeeEstimateResult_Id);
            
            AddColumn("dbo.Transaction", "FeeEstimateResult_Id", c => c.Int());
            AddForeignKey("dbo.Transaction", "FeeEstimateResult_Id", "dbo.FeeEstimateResult", "Id");
            CreateIndex("dbo.Transaction", "FeeEstimateResult_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Fee", new[] { "FeeEstimateResult_Id" });
            DropIndex("dbo.Transaction", new[] { "FeeEstimateResult_Id" });
            DropForeignKey("dbo.Fee", "FeeEstimateResult_Id", "dbo.FeeEstimateResult");
            DropForeignKey("dbo.Transaction", "FeeEstimateResult_Id", "dbo.FeeEstimateResult");
            DropColumn("dbo.Transaction", "FeeEstimateResult_Id");
            DropTable("dbo.Fee");
            DropTable("dbo.FeeEstimateResult");
        }
    }
}
