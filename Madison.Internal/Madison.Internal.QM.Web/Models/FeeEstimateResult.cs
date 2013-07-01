using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madison.Internal.QM.Web.Models
{
    [Table("FeeEstimateResult")]
    public class FeeEstimateResult
    {
        public int Id { get; set; }
        public bool WasSuccessful { get; set; }
        public string Message { get; set; }
        public virtual IList<Fee> Fees { get; set; }

        public FeeEstimateResult()
        {

        }
        
        public FeeEstimateResult(IList<Fee> fees, bool wasSuccessful, string message)
        {
            Fees = fees;
            WasSuccessful = wasSuccessful;
            Message = message;
        }

        public decimal GetTotalFeeAmount()
        {
            decimal total = 0;


            //subtract the 1200's from the calculation
            Fees.ToList().ForEach(fee => 
                    {
                        if (!fee.HudLine.StartsWith("12"))
                        {
                            total += fee.Amount;
                        }
                    });
            return total;
        }

        public string GetFeeSummaryText()
        {
            StringBuilder builder = new StringBuilder();

            List<string> feeSummaryList = GetFeeSummaryList();
            feeSummaryList.ForEach(feeSummary => builder.AppendLine(feeSummary));

            return builder.ToString();
        }

        public List<string> GetFeeSummaryList()
        {
            List<string> feeSummaryList = new List<string>();
            if (Fees != null)
            {
                Fees.ToList<Fee>().ForEach(fee =>
                {
                    feeSummaryList.Add(string.Format("Hud Line {0}: {1}", fee.HudLine, fee.Amount));
                });
            }

            return feeSummaryList;
        }
    }
}
