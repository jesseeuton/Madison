using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Madison.Internal.QM.Web.Models
{
    [Table("AffiliatedFees")]
    public class AffiliatedFees
    {
        public int Id { get; set; }

        [Display(Name = "Settlement Fee")]
        [DataType(DataType.Currency, ErrorMessage="Must be a number")]
        public decimal? TotalSettlementFee { get; set; }

        [Display(Name = "Appraisal Fee")]
        [DataType(DataType.Currency, ErrorMessage = "Must be a number")]
        public decimal? AppraisalFee { get; set; }

        [Display(Name = "Credit Fee")]
        [DataType(DataType.Currency, ErrorMessage = "Must be a number")]
        public decimal? CreditFee { get; set; }

        [Display(Name = "Total Third Party Origination Fee.")]
        [DataType(DataType.Currency, ErrorMessage = "Must be a number")]
        public decimal? MortageOriginatorCompensationAmount { get; set; }

        [Display(Name = "Survey Fee")]
        [DataType(DataType.Currency, ErrorMessage = "Must be a number")]
        public decimal? SurveyFee { get; set; }

        [Display(Name = "Notray Fee")]
        [DataType(DataType.Currency, ErrorMessage = "Must be a number")]
        public decimal? NotaryFee { get; set; }

        [Display(Name = "Inspection Fee")]
        [DataType(DataType.Currency, ErrorMessage = "Must be a number")]
        public decimal? InspectionFee { get; set; }

        [Display(Name = "Lender Fee")]
        [DataType(DataType.Currency, ErrorMessage = "Must be a number")]
        public decimal? LenderFee { get; set; }

        [Display(Name = "Escrow Fee")]
        [DataType(DataType.Currency, ErrorMessage = "Must be a number")]
        public decimal? EscrowFee { get; set; }

        [Display(Name = "PMI")]
        [DataType(DataType.Currency, ErrorMessage = "Must be a number")]
        public decimal? PMI { get; set; }
    }
}