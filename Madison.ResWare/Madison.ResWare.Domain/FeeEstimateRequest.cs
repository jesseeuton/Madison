using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madison.ResWare.Domain
{
    public class FeeEstimateRequest
    {
        public int ClientID { get; set; }
        public int OfficeID { get; set; }
        public int TransactionTypeID { get; set; }
        public int ProductTypeID { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string State { get; set; }
        public decimal LoanAmount { get; set; }
        public decimal SalesPrice { get; set; }
        public decimal OriginalDebtAmount { get; set; }
        public decimal UnpaidPrincipalAmount { get; set; }
    }
}
