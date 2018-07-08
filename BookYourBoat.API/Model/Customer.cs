using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace BookYourBoat.API.Model
{
    [DataContract]
    public class Customer
    {
        [DataMember(Name = "Name")]
        public string Name { get; set; }
        [DataMember(Name = "Id")]
        public int Id { get; set; }
        [DataMember(Name = "Email")]
        public string Email { get; set; }
        [DataMember(Name = "Password")]
        public string Password { get; set; }
        [DataMember(Name = "Address")]
        public Address Address { get; set; }
        [DataMember(Name = "Phone")]
        public Phone Phone { get; set; }
        [DataMember(Name = "IsActive")]
        public string IsActive { get; set; }
    }
}
