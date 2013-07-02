using System.Data.Entity;

namespace Madison.Internal.QM.Web.Models
{
    public class TransactionContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, add the following
        // code to the Application_Start method in your Global.asax file.
        // Note: this will destroy and re-create your database with every model change.
        // 
        //This should be in global asax
        // System.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<Madison.Internal.QM.Web.Models.Context>());

        public TransactionContext() : base("name=TransactionContext")
        {
        }

        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<AffiliatedFees> AffiliatedFees { get; set; }
        public DbSet<Borrower> Borrowers { get; set; }
        public DbSet<CompanyRelationship> CompanyRelationships { get; set; }
        public DbSet<Endorsement> Endorsements { get; set; }
        public DbSet<InterestType> InterestTypes { get; set; }
        public DbSet<LoanType> LoanTypes { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<PropertyType> PropertyTypes { get; set; }
        public DbSet<TransactionType> TransactionTypes { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<CapCalculationResult> CapCalculationResults { get; set; }
        public DbSet<CapCalculationResultInitial> CapCalculationResultsInitial { get; set; }
        public DbSet<CapCalculationResultFinal> CapCalculationResultsFinal { get; set; }
        public DbSet<FeeEstimateResult> FeeEstimateResults { get; set; }

        public DbSet<ReportModel> ReportModels { get; set; }
    }
}
