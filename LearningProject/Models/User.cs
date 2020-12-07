using LearningProject.Models.enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LearningProject.Models
{
    public class User
    {
        public int Id { get; set; }

        
        [Required(ErrorMessage = "Username is required")]
        [StringLength(16, ErrorMessage = "Must be between 3 and 16 characters", MinimumLength = 3)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(10, ErrorMessage = "Must be between 3 and 10 characters", MinimumLength = 3)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public Status Status { get; set; }

        public ICollection<Interest> Interests { get; set; } = new List<Interest>();

        public User() { }

        public User(int id, string username, string password)
        {
            Id = id;
            Username = username;
            Password = password;
            Status = (Status)2;
        }

        public void AddInterest( Interest interest)
        {
            Interests.Add(interest);
        }

        public List<Interest> FindAll()
        {
            return Interests.OrderBy(x => x.Name).ToList();
        }

        public bool ChangeStatus()
        {
            Status = (Status)1;
            return true;
        }
    }
}
