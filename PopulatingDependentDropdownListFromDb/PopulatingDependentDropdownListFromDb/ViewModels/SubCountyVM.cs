using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PopulatingDependentDropdownListFromDb.ViewModels
{
    public class SubCountyVM
    {
        public int id { get; set; }

        [StringLength(10)]
        [System.ComponentModel.DisplayName("Sub County Code*")]
        [Required]
        public string countyCode { get; set; }

        [StringLength(30)]
        [System.ComponentModel.DisplayName("Sub County Name*")]
        [Required]
        public string subCountyName { get; set; }

        public int? countyId { get; set; }
    }
}