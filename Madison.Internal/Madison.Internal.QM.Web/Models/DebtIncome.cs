using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Madison.Internal.QM.Web.Models
{
    [Table("DebtIncome")]
    public class DebtIncome
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public decimal MonthlyIncome { get; set; }    
        public virtual EmploymentStatus EmploymentStatus { get; set; }
        public virtual EmploymentLength EmploymentLength { get; set; }
        public virtual EmploymentLength EmploymentLengthAtPriorCompany { get; set; }
        public decimal ExpectedMonthlyPayment { get; set; }
        public bool RequiresPMI { get; set; }
        public decimal? ExpectedMonthlyPMI { get; set; }
        public bool AdditionalLoansOnProperty { get; set; }
        public decimal? TotalMontlyPaymentOfAdditionalLoans { get; set; }
        public decimal MonthlyDebtObligation { get; set; }

        [ForeignKey("EmploymentLength")]
        public int EmploymentLengthId { get; set; }
        [ForeignKey("EmploymentStatus")]
        public int EmploymentStatusId { get; set; }
        [ForeignKey("EmploymentLengthAtPriorCompany")]
        public int EmploymentLengthAtPriorCompanyId { get; set; }
    }

    [Table("EmploymentStatus")]
    public class EmploymentStatus
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
    }

    [Table("EmploymentLength")]
    public class EmploymentLength
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}