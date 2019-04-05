using System;
using System.Collections.Generic;

namespace CeoWebServices.Models
{
    public partial class States
    {
        public States()
        {
            Cities = new HashSet<Cities>();
        }

        public decimal Id { get; set; }
        public string Name { get; set; }
        public decimal CountryId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public decimal Flag { get; set; }

        public Countries Country { get; set; }
        public ICollection<Cities> Cities { get; set; }
    }
}
