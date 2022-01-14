using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolWebApplication.Models
{
    public class Teacher
    {
        public Teacher(int id, string name, string lastName, int payment, DateTime birthday)
        {
            Id=id;
            Name=name;
            LastName=lastName;
            Payment=payment;
            Birthday=birthday;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Payment { get; set; }
        public DateTime Birthday { get; set; } 
    }
}