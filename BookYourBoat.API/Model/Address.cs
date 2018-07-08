using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookYourBoat.API.Model
{
    public class Address
    {
        public int Id { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Zipcode { get; set; }
        public string State { get; set; }
        public ContactType Type { get; set; }
    }
}
