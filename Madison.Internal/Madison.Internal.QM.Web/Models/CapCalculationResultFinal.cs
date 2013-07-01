﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Madison.Internal.QM.Web.Models
{
    [Table("CapCalculationResultFinal")]
    public class CapCalculationResultFinal
    {
        public int Id { get; set; }
        public decimal Total { get; set; }
        
        [NotMapped]
        public List<string> Summary { get; set; }

        public CapCalculationResultFinal()
        {

        }
    }
}