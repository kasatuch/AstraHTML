using System.Collections.Generic;

namespace AstraHTML.Models
{
    public class Projects
    {
        public int id { get; set; }
        public string Title { get; set; }
        public string Client { get; set; }
        public string Description { get; set; }
        public List<Tasks> Tasks { get; set; }

    }
}
