using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Madison.Internal.QM.Web.Models
{
    [Table("Borrower")]
    public class Borrower
    {
        public int Id { get; set; }

        [Display(Name = "Borrower First Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Borrower First Name is required.")]
        public string FirstName { get; set; }

        [Display(Name = "Borrower First Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Borrower First Name is required.")]
        public string LastName { get; set; }
    }
}