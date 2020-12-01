using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningProject.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public ICollection<Interest> Interests { get; set; } = new List<Interest>();

        public User() { }

        public User(int id, string username, string password)
        {
            Id = id;
            Username = username;
            Password = password;
        }

        public void AddInterest( Interest interest)
        {
            Interests.Add(interest);
        }

        public List<Interest> FindAll()
        {
            return Interests.OrderBy(x => x.Name).ToList();
        }

    }
}
