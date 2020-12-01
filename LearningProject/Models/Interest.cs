using LearningProject.Models.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningProject.Models
{
    public class Interest
    {
        public string Name { get; set; }

        public InterestStatus InterestStatus { get; set; }

        public Interest(string name, InterestStatus interestStatus)
        {
            Name = name;
            InterestStatus = interestStatus;
        }
    }


}
