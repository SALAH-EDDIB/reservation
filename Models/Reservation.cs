using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace reservation.Models
{
    public class Reservation
    {

        public int Id { get; set; }
        public DateTime  Date { get; set; }
        public User User  { get; set; }
        public ReservationType ReservationType  { get; set; }
        public bool IsValid { get; set; }



    }
}
