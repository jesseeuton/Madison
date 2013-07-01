namespace Madison.Internal.QM.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class capcalculationtables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CapCalculationResult",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TransactionId = c.Int(nullable: false),
                        UnderCap = c.Boolean(nullable: false),
                        CapAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AmountRemainingUnderCap = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AffiliatedFeesResult_Id = c.Int(),
                        PriorFeesResult_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CapCalculationInitial", t => t.AffiliatedFeesResult_Id)
                .ForeignKey("dbo.CapCalculationResultFinals", t => t.PriorFeesResult_Id)
                .Index(t => t.AffiliatedFeesResult_Id)
                .Index(t => t.PriorFeesResult_Id);
            
            CreateTable(
                "dbo.CapCalculationInitial",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CapCalculationResultFinals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Transaction", "CapCalculationResult_Id", c => c.Int());
            AddForeignKey("dbo.Transaction", "CapCalculationResult_Id", "dbo.CapCalculationResult", "Id");
            CreateIndex("dbo.Transaction", "CapCalculationResult_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.CapCalculationResult", new[] { "PriorFeesResult_Id" });
            DropIndex("dbo.CapCalculationResult", new[] { "AffiliatedFeesResult_Id" });
            DropIndex("dbo.Transaction", new[] { "CapCalculationResult_Id" });
            DropForeignKey("dbo.CapCalculationResult", "PriorFeesResult_Id", "dbo.CapCalculationResultFinals");
            DropForeignKey("dbo.CapCalculationResult", "AffiliatedFeesResult_Id", "dbo.CapCalculationInitial");
            DropForeignKey("dbo.Transaction", "CapCalculationResult_Id", "dbo.CapCalculationResult");
            DropColumn("dbo.Transaction", "CapCalculationResult_Id");
            DropTable("dbo.CapCalculationResultFinals");
            DropTable("dbo.CapCalculationInitial");
            DropTable("dbo.CapCalculationResult");
        }
    }
}
