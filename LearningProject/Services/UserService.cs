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

        public async Task AuthenticationAsync(User obj)
        {

            bool hasAny = await _context.Users.AnyAsync(x => x.Username == obj.Username && x.Password == obj.Password);
            if (!hasAny)
            {
                throw new Exception("Login Failed");
            }
            //try catch aqui

            //redireciona para proxima pag
            await _context.SaveChangesAsync();

        }
    }
    }
