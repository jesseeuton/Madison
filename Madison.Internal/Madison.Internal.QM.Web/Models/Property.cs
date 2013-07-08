using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Madison.Internal.QM.Web.Models
{
    [Table("Property")]
    public class Property
    {
        public int Id { get; set; }

        [Display(Name="Address 1")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Required.")]
        public string Address1 { get; set; }

        [Display(Name = "Address 2")]
        public string Address2 { get; set; }

        [Display(Name = "City")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Required.")]
        public string City { get; set; }

        [Display(Name = "County")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Required.")]
        public string County { get; set; }

        [Display(Name = "State")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Required.")]
        public string State { get; set; }

        [Display(Name = "Zip Code")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Required.")]
        public string Zip { get; set; }

        [ForeignKey("PropertyType")]
        public int PropertyTypeId { get; set; }

        [Display(Name = "Property Type")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Required.")]
        public PropertyType PropertyType { get; set; }
    }
}