using System;
using System.Collections.Generic;
using System.Text;

namespace AstraHTML.Models
{
   public class Tasks
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Staff> Developers { get; set; }
        public virtual Projects Project { get; set; }
        public int Projectid { get; set; }
        public string Priority { get; set; }

    }
}
