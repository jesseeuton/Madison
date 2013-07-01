using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Madison.Internal.QM.Web.Models
{
    [Table("TransactionType")]
    public class TransactionType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ResWareTransactionTypeId { get; set; }
        public int ResWareProductTypeId { get; set; }
    }
}