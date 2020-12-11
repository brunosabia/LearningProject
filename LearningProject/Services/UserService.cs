using LearningProject.Data;
using LearningProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningProject.Services
{
    public class UserService
    {
        private readonly LoginContext _context;

        public UserService(LoginContext context)
        {
            _context = context;
        }

        public async Task<List<User>> FindAllAsync()
        {
            return await _context.User.ToListAsync();
            //User u1 = new User(12, "danilo", "dandan", Models.enums.Status.Offline);
            //return u1;
        }


        public async Task InsertAsync(User obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<User> AuthenticationAsync(string username, string password)
        {
            User u1 = new User(999, username, password, Models.enums.Status.Offline);
            bool hasAny = await _context.User.AnyAsync(x => x.Username == username && x.Password == password);
            if (!hasAny)
            {
                throw new Exception("Login Failed");
                
            }

            else
            {
                User u2 = await _context.User.FirstOrDefaultAsync(x => x.Username == username && x.Password == password);
                u2.ChangeStatus(Models.enums.Status.Online);
                
                await _context.SaveChangesAsync();
                return u2;
                
            }
            

        }

        internal Task FirstOrDefaultAsync(Func<object, bool> p)
        {
            throw new NotImplementedException();
        }
    }
    }
