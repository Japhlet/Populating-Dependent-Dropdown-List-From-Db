namespace PopulatingDependentDropdownListFromDb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("county")]
    public partial class county
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public county()
        {
            subCounty = new HashSet<subCounty>();
        }

        public int id { get; set; }

        [StringLength(30)]
        public string countyCode { get; set; }

        [StringLength(30)]
        public string countyName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<subCounty> subCounty { get; set; }
    }
}
