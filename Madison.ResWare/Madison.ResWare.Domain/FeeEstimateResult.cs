using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madison.ResWare.Domain
{
    public class FeeEstimateResult
    {
        public IList<Fee> Fees { get; set; }
        public decimal TotalFeeAmount { get; set; }
        public string FeeSummaryText { get; set; }
        public bool WasSuccessful { get; set; }
        public string Message { get; set; }
        
        public FeeEstimateResult(IList<Fee> fees, bool wasSuccessful, string message)
        {
            Fees = fees;
            WasSuccessful = wasSuccessful;
            Message = message;
            TotalFeeAmount = GetTotalFeeAmount();
            FeeSummaryText = GetFeeSummaryText();
        }

        public decimal GetTotalFeeAmount()
        {
            decimal total = 0;

            if (Fees != null)
                Fees.ToList().ForEach(fee => total += fee.Amount);

            return total;
        }

        public string GetFeeSummaryText()
        {
            StringBuilder builder = new StringBuilder();

            if (Fees != null)
            {
                Fees.ToList<Fee>().ForEach(fee =>
                {
                    builder.AppendLine(string.Format("Hud Line {0}: {1}", fee.HudLine, fee.Amount));
                });
            }

            return builder.ToString();
        }
    }
}
