using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Madison.Internal.QM.Web.Models
{
    [Table("Transaction")]
    public class Transaction
    {
        public virtual TransactionType TransactionType { get; set; }
        public virtual LoanType LoanType { get; set; }
        public virtual InterestType InterestType { get; set; }
        public virtual Property Property { get; set; }
        public virtual UserProfile UserProfile { get; set; }
        public virtual Borrower Borrower { get; set; }
        public virtual AffiliatedFees AffiliatedFee { get; set; }
        public virtual List<Endorsement> Endorsements { get; set; }
        public virtual FeeEstimateResult FeeEstimateResult { get; set; }
        public virtual CapCalculationResult CapCalculationResult { get; set; }

        public int Id { get; set; }

        #region Foreign Keys
        [ForeignKey("TransactionType")]
        public int? TransactionTypeId { get; set; }

        [ForeignKey("LoanType")]
        public int? LoanTypeId { get; set; }

        [ForeignKey("InterestType")]
        public int? InterestTypeId { get; set; }

        [ForeignKey("Property")]
        public int? PropertyId { get; set; }

        [ForeignKey("UserProfile")]
        public int? UserProfileId { get; set; }

        [ForeignKey("Borrower")]
        public int? BorrowerId { get; set; }

        [ForeignKey("FeeEstimateResult")]
        public int? FeeEstimateResultId { get; set; }

        [ForeignKey("CapCalculationResult")]
        public int? CapCalculationResultId { get; set; }
        #endregion
         
        [Display(Name = "Loan Amount")]
        [DataType(DataType.Currency, ErrorMessage = "Must be a number")]
        public decimal LoanAmount { get; set; }

        [Display(Name = "Original Debt Amount")]
        [DataType(DataType.Currency, ErrorMessage = "Must be a number")]
        public decimal? OriginalDebtAmount { get; set; }

        [Display(Name = "Sale Price")]
        [DataType(DataType.Currency, ErrorMessage = "Must be a number")]
        public decimal? SalePrice { get; set; }

        [Display(Name = "Unpaid Principal")]
        [DataType(DataType.Currency, ErrorMessage = "Must be a number")]
        
        public decimal? UnpaidPrincipalAmount { get; set; }

        #region Seller
        [Display(Name = "Prior Lender Policy Date")]
        public DateTime? SellerPriorLenderPolicyDate { get; set; }

        [Display(Name = "Prior Lender Policy Amount")]
        public decimal? SellerPriorLenderPolicyAmount { get; set; }

        [Display(Name = "Unpaid Balance Of Prior Loan")]
        public decimal? SellerUnpaidBalanceOfPriorLoan { get; set; }

        [Display(Name = "Prior Owner Policy Date")]
        public DateTime? SellerPriorOwnerPolicyDate { get; set; }

        [Display(Name = "Prior Owner Policy Amount")]
        public decimal? SellerPriorOwnerPolicyAmount { get; set; }

        [Display(Name = "Unpaid Balance")]
        public decimal? SellerUnpaidBalance { get; set; }

        [Display(Name = "Prior Lender Policy Available As Proof")]
        public bool SellerPriorLenderPolicyAvailableAsProof { get; set; }

        [Display(Name = "Prior Owner Policy Is Available As Proof")]
        public bool SellerPriorOwnerPolicyAvailableAsProof { get; set; }

        #endregion

        #region Buyer
        [Display(Name = "Prior Lender Policy Date")]
        public DateTime? BuyerPriorLenderPolicyDate { get; set; }

        [Display(Name = "Prior Lender Policy Amount")]
        public decimal? BuyerPriorLenderPolicyAmount { get; set; }

        [Display(Name = "Unpaid Balance Of Prior Loan")]
        public decimal? BuyerUnpaidBalanceOfPriorLoan { get; set; }

        [Display(Name = "Prior Owner Policy Date")]
        public DateTime? BuyerPriorOwnerPolicyDate { get; set; }

        [Display(Name = "Prior Owner Policy Amount")]
        public decimal? BuyerPriorOwnerPolicyAmount { get; set; }

        [Display(Name = "Unpaid Balance")]
        public decimal? BuyerUnpaidBalance { get; set; }

        [Display(Name = "Prior Lender Policy Available As Proof")]
        public bool BuyerPriorLenderPolicyAvailableAsProof { get; set; }

        [Display(Name = "Prior Owner Policy Is Available As Proof")]
        public bool BuyerPriorOwnerPolicyAvailableAsProof { get; set; }

        #endregion
    }
}