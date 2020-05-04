using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_all.Models
{
    public class EmpModel
    {

        public int id { get; set; }
        public int gender { get; set; }
        public string name { get; set; }
        public int deptid { get; set; }
        public decimal salary { get; set; }

    }

     public class dept {

        public int deptid { get; set; }
        public string deptname { get; set; }
    }

    public class EmpView 
    {
        [Required]
        public int id { get; set; }
        public int gender { get; set; }
        [Required]
        public string name { get; set; }
        public int deptid { get; set; }
        public decimal salary { get; set; }

        public string deptname { get; set; }
        public List<dept> depts { get; set; }
       public List<genderTypes> genderList = new List<genderTypes>();

        public EmpView()
        {
            genderList.Add(new genderTypes { type="male",id=1});
            genderList.Add(new genderTypes { type = "female", id = 2 });
        }

    }

    public class genderTypes {
        public string type { get; set; }
        public int id { get; set; }
    }
}