using System;
using System.Collections.Generic;
using Target.Domain.Entities;

namespace Target.Site.Models
{
    public class RegisterCustomerViewModel
    {
        public int Id { get; set; }
        public int Role { get; set; }
        public string Username { get; set; }
        public string Fullname { get; set; }
        public string BirthDate { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string Active { get; set; }
    }
}
