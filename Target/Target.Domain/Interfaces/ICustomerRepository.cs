using System;
using System.Collections.Generic;
using System.Text;
using Target.Domain.Entities;

namespace Target.Domain.Interfaces
{
    public  interface ICustomerRepository
    {
        IEnumerable<Customer> GetList();
        Customer GetById(int id);
        void Delete(int id);
        void Insert(Customer customer);
        void Update(Customer customer);
        int? ExistByEmail(string email);
        int? ExistByUsername(string username);
    }
}
