using System;
using System.Collections.Generic;
using System.Text;
using Target.Domain.Entities;

namespace Target.Domain.Interfaces
{
    public  interface IRoleRepository
    {
        IEnumerable<Role> GetList();
        Role GetById(int Id);
    }
}
