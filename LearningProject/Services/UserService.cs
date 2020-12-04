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
            return await _context.Users.ToListAsync();
        }


        public async Task InsertAsync(User obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<User> AuthenticationAsync(string username, string password)
        {
            User u1 = new User(9, username, password);
            bool hasAny = await _context.Users.AnyAsync(x => x.Username == username && x.Password == password);
            if (!hasAny)
            {
                throw new Exception("Login Failed");
            }

            else
            {
                await _context.SaveChangesAsync();
                return u1;
                
            }
            //try catch aqui

            //redireciona para proxima pag
            

        }
    }
    }
