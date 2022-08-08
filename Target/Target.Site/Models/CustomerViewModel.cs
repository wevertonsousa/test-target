using System;
using System.Collections.Generic;
using Target.Domain.Entities;

namespace Target.Site.Models
{
    public class CustomerViewModel
    {
        public List<Role> Roles { get; set; }
        public Customer Customer { get; set; }
    }
}
