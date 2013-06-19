using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Madison.Internal.QM.Web.Models;

namespace Madison.Internal.QM.Web.ViewModels
{
    public class TransactionViewModel : BaseViewModel
    {
        public List<TransactionType> TransactionTypes { get; set; }
        public List<LoanType> LoanTypes { get; set; }
        public List<InterestType> InterestTypes { get; set; }
        public List<Endorsement> Endorsements { get; set; }
        public Transaction Transaction { get; set; }
    }
}