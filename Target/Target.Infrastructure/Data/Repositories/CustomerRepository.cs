using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Target.Domain.Entities;
using Target.Domain.Interfaces;
using Target.Infrastructure.Data.DataContext;
using System.Linq;

namespace Target.Infrastructure.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IDataBaseService _context;

        public CustomerRepository(IDataBaseService context)
        {
            _context = context;
        }
        public IEnumerable<Customer> GetList()
        {
            var sqlQuery = @"SELECT c.Id,
                            c.Username,
                            c.Fullname,
                            c.BirthDate,
                            c.Country,
                            c.Email,
                            c.Active,
                            r.Id,
                            r.Name
                        FROM Customer c
                        INNER JOIN Role r
                        ON c.RoleId = r.Id;";

			using var conn = _context.GetConnection();

			var result = conn.Query<Customer>(sqlQuery,
			new[]
			{
				typeof(Customer),
				typeof(Role)
			},
			objects =>
			{
				var customer = objects[0] as Customer;
				var role = objects[1] as Role;

                customer.Role = role;
				return customer;
			}, splitOn: "Id, Id").ToList();

            return result;
        }
        public void Delete(int id)
        {
            var sqlQuery = "DELETE FROM Customer WHERE Id=@id";
            using var conn = _context.GetConnection();
            conn.Execute(sqlQuery, new { id });
        }

        public Customer GetById(int id)
        {
            var sqlQuery = @"SELECT c.Id,
                            c.Username,
                            c.Fullname,
                            c.BirthDate,
                            c.Country,
                            c.Email,
                            c.Active,
                            r.Id,
                            r.Name
                        FROM Customer c
                        INNER JOIN Role r
                        ON c.RoleId = r.Id
                        WHERE c.Id = @id;";

            using var conn = _context.GetConnection();

            var result = conn.Query<Customer>(sqlQuery,
            new[]
            {
                typeof(Customer),
                typeof(Role)
            },
            objects =>
            {
                var customer = objects[0] as Customer;
                var role = objects[1] as Role;

                customer.Role = role;
                return customer;
            }, new { id } , splitOn: "Id, Id").FirstOrDefault();

            return result;
        }
        public int? ExistByEmail(string email)
        {
            string sqlQuery = "SELECT Id FROM Customer WHERE Email=@email";
            using var conn = _context.GetConnection();
            var result = conn.QueryFirstOrDefault<int>(sqlQuery, new { email });
            return result;
        }
        public int? ExistByUsername(string username)
        {
            string sqlQuery = "SELECT Id FROM Customer WHERE Username=@username";
            using var conn = _context.GetConnection();
            var result = conn.QueryFirstOrDefault<int>(sqlQuery, new { username });
            return result;
        }

        public void Insert(Customer customer)
        {
            string sqlQuery = @"INSERT INTO Customer (
                                RoleId, 
                                Username,
                                FullName,
                                BirthDate,
                                Country,
                                Email,
                                Active,
                                RegistrationDate) VALUES (
                                @RoleId,
                                @Username,
                                @FullName,
                                @BirthDate,
                                @Country,
                                @Email,
                                @Active,
                                getdate()
                                );";
            using var conn = _context.GetConnection();
            var result = conn.Execute(sqlQuery, new 
            { 
                RoleId = customer.Role.Id,
                customer.Username,
                customer.Fullname,
                customer.BirthDate,
                customer.Country,
                customer.Email,
                customer.Active
            });
        }

        public void Update(Customer customer)
        {
            string sqlQuery = @"UPDATE Customer 
                                SET RoleId = @RoleId, 
                                    Username = @Username,
                                    FullName = @FullName,
                                    BirthDate = @BirthDate,
                                    Country = @Country,
                                    Email = @Email,
                                    Active = @Active,
                                    ChangeDate = getdate()
                                WHERE Id = @Id;";
            using var conn = _context.GetConnection();
            var result = conn.Execute(sqlQuery, new
            {
                RoleId = customer.Role.Id,
                customer.Username,
                customer.Fullname,
                customer.BirthDate,
                customer.Country,
                customer.Email,
                customer.Active,
                customer.Id
            });
        }
    }
}
