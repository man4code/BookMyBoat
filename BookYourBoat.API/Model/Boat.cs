using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookYourBoat.API.Model
{
    public class Boat
    {
        public BoatType Type { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
