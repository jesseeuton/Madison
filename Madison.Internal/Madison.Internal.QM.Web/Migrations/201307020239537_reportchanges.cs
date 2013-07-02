namespace Madison.Internal.QM.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reportchanges : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.ReportModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ReportModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.Reports");
        }
    }
}
