namespace PopulatingDependentDropdownListFromDb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("subCounty")]
    public partial class subCounty
    {
        public int id { get; set; }

        [StringLength(10)]
        public string subCountyCode { get; set; }

        [StringLength(30)]
        public string subCountyName { get; set; }

        public int? countyId { get; set; }

        public virtual county county { get; set; }
    }
}
