using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Target.Domain.Entities;
using Target.Domain.Interfaces;
using Target.Infrastructure.Data.DataContext;

namespace Target.Infrastructure.Data.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly IDataBaseService _context;

        public RoleRepository(IDataBaseService context)
        {
            _context = context;
        }
        public IEnumerable<Role> GetList()
        {
            var sqlQuery = @"SELECT r.Id,
                             r.Name
                             FROM Role r;";

			using var conn = _context.GetConnection();

			var result = conn.Query<Role>(sqlQuery);
            return result;
        }
        public Role GetById(int Id)
        {
            var sqlQuery = @"SELECT r.Id,
                             r.Name
                             FROM Role r
                             WHERE r.Id = @Id;";

            using var conn = _context.GetConnection();

            var result = conn.QueryFirstOrDefault<Role>(sqlQuery, new { Id });
            return result;
        }
    }
}
