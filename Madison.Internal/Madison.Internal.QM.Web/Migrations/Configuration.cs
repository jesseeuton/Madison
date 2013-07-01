namespace Madison.Internal.QM.Web.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Madison.Internal.QM.Web.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Madison.Internal.QM.Web.Models.TransactionContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Madison.Internal.QM.Web.Models.TransactionContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //context.UserProfiles.AddOrUpdate(p => p.Username, 
            //    new UserProfile() { FirstName="Cynthia", comp

            context.CompanyRelationships.AddOrUpdate(p => p.Name,
                new CompanyRelationship { Name="Manager" },
                new CompanyRelationship { Name="Loan Officer" },
                new CompanyRelationship { Name="Broker" },
                new CompanyRelationship { Name="Realtor" },
                new CompanyRelationship { Name="Processor" },
                new CompanyRelationship { Name="Builder" }
            );

            context.TransactionTypes.AddOrUpdate(p => p.Name,
                new TransactionType { Name = "Refinance" },
                new TransactionType { Name = "Purchase" },
                new TransactionType { Name = "Reverse" }
                );

            context.Endorsements.AddOrUpdate(p => p.Name,
                new Endorsement { Name = "Planned Unit Development", DefaultSelect=false },
                new Endorsement { Name = "Survey Coverage", DefaultSelect = false },
                new Endorsement { Name = "Condo", DefaultSelect = false },
                new Endorsement { Name = "Variable Rate Endorsement", DefaultSelect = false },
                new Endorsement { Name = "Variable Rate, Negative Am", DefaultSelect = false },
                new Endorsement { Name = "Manufactured Housing", DefaultSelect = false },
                new Endorsement { Name = "Environmental Protection", DefaultSelect = true },
                new Endorsement { Name = "Restrictions, Encroachments, Minerals", DefaultSelect = true }
                );

            context.InterestTypes.AddOrUpdate(p => p.Name,
                new InterestType { Name = "Fixed" },
                new InterestType { Name = "Vairable Rate" },
                new InterestType { Name = "Variable Rate, Negative Am" }
                );

            context.LoanTypes.AddOrUpdate(p => p.Name,
                new LoanType { Name = "FHA" },
                new LoanType { Name="VA"},
                new LoanType { Name="Conventional"},
                new LoanType { Name="Equity"}, 
                new LoanType { Name="Equity Line of Credit" },
                new LoanType { Name="Cash Out"},
                new LoanType { Name="Construction"} );

            context.PropertyTypes.AddOrUpdate(p => p.Name,
                new PropertyType { Name = "Single Family" },
                new PropertyType { Name = "Condo" },
                new PropertyType { Name = "Investment" },
                new PropertyType { Name = "Manufactured Housing" },
                new PropertyType { Name = "Unimproved Land" }
                );

           
        }
    }
}
