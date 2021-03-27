using Pixelstats.Data.Interfaces;
using Pixelstats.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pixelstats.Data.Repositories
{
    public class UserRepository : IGetUsers
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetUsers() => _context.Users;
    }
}
