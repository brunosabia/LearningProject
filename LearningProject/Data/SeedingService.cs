using LearningProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningProject.Data
{
    public class SeedingService
    {
        private LoginContext _context;

        public SeedingService(LoginContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Users.Any())
            {
                return;
            }

            User u1 = new User(1, "bruno", "1234", Models.enums.Status.Offline);
            User u2 = new User(2, "bruno1", "1234", Models.enums.Status.Offline);
            User u3 = new User(3, "bruno2", "1234", Models.enums.Status.Offline);

            _context.Users.AddRange(u1, u2, u3);
            _context.SaveChanges();

        }
    }
}
