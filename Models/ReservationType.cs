using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace reservation.Models
{
    public class ReservationType
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int NumberOfPlaces { get; set; }
    }
}
