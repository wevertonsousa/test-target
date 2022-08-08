using System;
using System.Collections.Generic;
using System.Text;

namespace Target.Domain.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public Role Role { get; set; }
        public string Username { get; set; }
        public string Fullname { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }
    }
}
