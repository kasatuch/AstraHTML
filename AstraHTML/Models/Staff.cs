using System;
using System.Collections.Generic;
using System.Text;

namespace AstraHTML.Models
{
   public class Staff
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Speciality { get; set; }
        public string Post { get; set; }
        public int Salary { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public virtual Tasks Tasks { get; set; }
        public int TasksId { get; set; }

    }
}
