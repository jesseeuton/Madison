namespace Madison.Internal.QM.Web.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Madison.Internal.QM.Web.Models;

    //internal sealed class GeneralConfiguration : DbMigrationsConfiguration<Madison.Internal.QM.Web.Models.GeneralContext>
    //{
        
    //    public GeneralConfiguration()
    //    {
    //        AutomaticMigrationsEnabled =false;
    //    }

    //    protected override void Seed(Madison.Internal.QM.Web.Models.GeneralContext context)
    //    {

                
    //    }
        
    //}

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

            context.CompanyRelationships.AddOrUpdate(p => p.Name,
                new CompanyRelationship { Name="Manager" },
                new CompanyRelationship { Name="Loan Officer" },
                new CompanyRelationship { Name="Broker" },
                new CompanyRelationship { Name="Realtor" },
                new CompanyRelationship { Name="Processor" },
                new CompanyRelationship { Name="Builder" }
            );

            context.TransactionTypes.AddOrUpdate(p => p.Name,
                new TransactionType { Name = "Refinance", ResWareTransactionTypeId = 2, ResWareProductTypeId = 7 },
                new TransactionType { Name = "Purchase", ResWareTransactionTypeId = 3, ResWareProductTypeId = 4 },
                new TransactionType { Name = "Reverse", ResWareTransactionTypeId = 4, ResWareProductTypeId = 8 },  //TODO:  This is not correct
                new TransactionType { Name = "Home Equity", ResWareTransactionTypeId = 4, ResWareProductTypeId = 8 },  //TODO:  This is not correct
                new TransactionType { Name = "Home Equity LOC", ResWareTransactionTypeId = 5, ResWareProductTypeId = 8 }  //TODO:  This is not correct
                );

            context.Endorsements.AddOrUpdate(p => p.Name,
                new Endorsement { Name = "Planned Unit Development", Selected=true },
                new Endorsement { Name = "Survey Coverage", Selected = true },
                new Endorsement { Name = "Condo", Selected = false },
                new Endorsement { Name = "Variable Rate Endorsement", Selected = false },
                new Endorsement { Name = "Variable Rate, Negative Am", Selected = false },
                new Endorsement { Name = "Manufactured Housing", Selected = false },
                new Endorsement { Name = "Environmental Protection", Selected = true },
                new Endorsement { Name = "Restrictions, Encroachments, Minerals", Selected = true }
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

            context.EmploymentLength.AddOrUpdate(p => p.Name,
                new EmploymentLength { Name = "< 6 Months" },
                new EmploymentLength { Name = "6 Months - 1 Year" },
                new EmploymentLength { Name = "1 Year - 3 Years" },
                new EmploymentLength { Name = "3 Years - 5 Years" },
                new EmploymentLength { Name = "> 5 Years" });

            context.EmploymentStatus.AddOrUpdate(p => p.Name,
                new EmploymentStatus { Name = "Employed" },
                new EmploymentStatus { Name = "Unemployed" });

           
        }
    }
}
