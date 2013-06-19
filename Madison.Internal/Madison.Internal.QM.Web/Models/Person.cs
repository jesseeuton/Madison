using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Madison.Internal.QM.Web.Models
{
    [Table("Person")]
    public class Person
    {
        public int Id { get; set; }

        [Display(Name = "First Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "First Name is required.")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Last Name is required.")]
        public string LastName { get; set; }

        [Display(Name = "Company Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Company Name is required.")]
        public string CompanyName { get; set; }

        [Display(Name = "Affilation")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Affiliation is required.")]
        public CompanyRelationship Relationship { get; set; }

        [Display(Name = "Email Address")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email Address is required.")]
        public string EmailAddress { get; set; }

        [Display(Name = "Phone")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Phone is required.")]
        public string Phone { get; set; }
    }
}