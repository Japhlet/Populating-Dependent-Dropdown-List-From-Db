﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PopulatingDependentDropdownListFromDb.Repositories
{
    public class CountyRepo
    {
        public IList<SelectListItem> countyNames { get; set; }
        
    }
}