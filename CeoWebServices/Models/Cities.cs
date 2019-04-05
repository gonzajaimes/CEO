using System;
using System.Collections.Generic;

namespace CeoWebServices.Models
{
    public partial class Cities
    {
        public decimal Id { get; set; }
        public string Name { get; set; }
        public decimal StateId { get; set; }
        public decimal CountryId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedOn { get; set; }
        public decimal Flag { get; set; }

        public Countries Country { get; set; }
        public States State { get; set; }
    }
}
