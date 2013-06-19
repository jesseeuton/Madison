using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Madison.Internal.QM.Web.Models
{
    [Table("CompanyRelationship")]
    public class CompanyRelationship
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}