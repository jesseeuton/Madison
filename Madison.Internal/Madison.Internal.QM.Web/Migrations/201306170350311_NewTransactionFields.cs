namespace Madison.Internal.QM.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewTransactionFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transaction", "PriorLenderPolicyAvailableAsProof", c => c.Boolean(nullable: false));
            AddColumn("dbo.Transaction", "PriorOwnersPolicyAvailableAsProof", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Transaction", "PriorOwnersPolicyAvailableAsProof");
            DropColumn("dbo.Transaction", "PriorLenderPolicyAvailableAsProof");
        }
    }
}
