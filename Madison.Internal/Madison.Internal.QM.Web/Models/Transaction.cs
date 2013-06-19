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
        public int Id { get; set; }
        public virtual TransactionType TransactionType { get; set; }
        public virtual LoanType LoanType { get; set; }
        public virtual PropertyType PropertyType { get; set; }
        public virtual InterestType InterestType { get; set; }
        public virtual Property Property { get; set; }
        public virtual Person Person { get; set; }
        public virtual Borrower Borrower { get; set; }
        public virtual AffiliatedFees AffiliatedFee { get; set; }
        public virtual List<Endorsement> Endorsements { get; set; }
         
        [Display(Name = "Loan Amount")]
        [Required(AllowEmptyStrings=false, ErrorMessage="Loan Amount is required.")]
        public decimal LoanAmount { get; set; }

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

        //20.	Unpaid balance of loan if seller for purchase reissue calculation only
        [Display(Name = "Unpaid Balance")]
        public decimal? BuyerUnpaidBalance { get; set; }

        [Display(Name = "Prior Lender Policy Available As Proof")]
        public bool BuyerPriorLenderPolicyAvailableAsProof { get; set; }

        [Display(Name = "Prior Owner Policy Is Available As Proof")]
        public bool BuyerPriorOwnerPolicyAvailableAsProof { get; set; }

        #endregion

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

        //20.	Unpaid balance of loan if seller for purchase reissue calculation only
        [Display(Name = "Unpaid Balance")]
        public decimal? SellerUnpaidBalance { get; set; }

        [Display(Name = "Prior Lender Policy Available As Proof")]
        public bool SellerPriorLenderPolicyAvailableAsProof { get; set; }
        #endregion

        [Display(Name = "Prior Owner Policy Is Available As Proof")]
        public bool SellerPriorOwnerPolicyAvailableAsProof { get; set; }
    }
}