using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookYourBoat.API.Model
{
    public class Payment
    {
        public int Id { get; set; }
        public Boat Boat { get; set; }
        public Customer User { get; set; }
        public string Cost { get; set; }
        public string Duration { get; set; }
    }
}
