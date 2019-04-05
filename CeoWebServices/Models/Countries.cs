using System;
using System.Collections.Generic;

namespace CeoWebServices.Models
{
    public partial class Countries
    {
        public Countries()
        {
            Cities = new HashSet<Cities>();
            States = new HashSet<States>();
        }

        public decimal Id { get; set; }
        public string Name { get; set; }
        public string Iso3 { get; set; }
        public string Iso2 { get; set; }
        public string Phonecode { get; set; }
        public string Capital { get; set; }
        public string Currency { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public decimal Flag { get; set; }

        public ICollection<Cities> Cities { get; set; }
        public ICollection<States> States { get; set; }
    }
}
