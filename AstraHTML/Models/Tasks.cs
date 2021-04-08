using AstraHTML.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AstraHTML.Models
{
   public class Tasks
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Staff> Staff { get; set; }
        public int Staffid { get; set; }
        public virtual Projects Project { get; set; }
        public int Projectid { get; set; }
        public string Priority { get; set; }

        [NotMapped]
        public  Projects TaskProject
        {
            get
            {
                return DataWorker.GetProjectTitleByid(Projectid);
            } 
        }


    }
}
