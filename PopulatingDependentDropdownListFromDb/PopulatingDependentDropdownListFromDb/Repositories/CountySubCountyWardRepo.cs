using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PopulatingDependentDropdownListFromDb.Repositories
{
    public class CountySubCountyWardRepo
    {
        public IList<SelectListItem> countyNames { get; set; }
        public IList<SelectListItem> subCountyNames { get; set; }
    }
}