using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookYourBoat.API.Model
{
    public class Phone
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public ContactType Type { get; set; }
    }
}
