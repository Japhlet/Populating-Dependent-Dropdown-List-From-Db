using System.ComponentModel.DataAnnotations;

namespace PopulatingDependentDropdownListFromDb.ViewModels
{
    public class CountyVM
    {
        public int id { get; set; }

        [StringLength(30)]
        [System.ComponentModel.DisplayName("County Code*")]
        [Required]
        public string countyCode { get; set; }

        [StringLength(30)]
        [System.ComponentModel.DisplayName("County Name*")]
        [Required]
        public string countyName { get; set; }
    }
}