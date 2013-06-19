using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Madison.Internal.QM.Web.Models;

namespace Madison.Internal.QM.Web.ViewModels
{
    public class PersonViewModel : BaseViewModel
    {
        public Person Person { get; set; }
        public List<CompanyRelationship> CompanyRelationships { get; set; }
    }
}