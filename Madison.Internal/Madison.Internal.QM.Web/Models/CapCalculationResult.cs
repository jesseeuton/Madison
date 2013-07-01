using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Madison.Internal.QM.Web.Models
{
    [Table("CapCalculationResult")]
    public class CapCalculationResult
    {
        public int Id { get; set; }
        [ForeignKey("CapCalculationResultInitial")]
        public int? CapCalculationResultInitialId { get; set; }
        [ForeignKey("CapCalculationResultFinal")]
        public int? CapCalculationResultFinalId { get; set; }

        public virtual CapCalculationResultInitial CapCalculationResultInitial { get; set; }
        public virtual CapCalculationResultFinal CapCalculationResultFinal { get; set; }

        public bool UnderCap { get; set; }

        [DataType(DataType.Currency)]
        public decimal CapAmount { get; set; }
        [DataType(DataType.Currency)]
        public decimal AmountRemainingUnderCap { get; set; }

        public CapCalculationResult()
        {
        }
    }
}