using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Madison.Internal.QM.Web.Models;

namespace Madison.Internal.QM.Web.ViewModels
{
    public class BorrowerViewModel : BaseViewModel
    {
        public Borrower Borrower { get; set; }
        public Property Property { get; set; }
        public List<PropertyType> PropertyTypes { get; set; }
    }
}