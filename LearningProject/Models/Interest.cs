using LearningProject.Models.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningProject.Models
{
    public class Interest
    {
        public int InterestID { get; set; }
        public string Name { get; set; }

        public InterestStatus InterestStatus { get; set; }

        public Interest(int interestID, string name, InterestStatus interestStatus)
        {
            InterestID = interestID;
            Name = name;
            InterestStatus = interestStatus;
        }
    }


}
