using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC_all.Models;

namespace MVC_all.Comp
{
    public class InMemoryDBComp : IDBComp
    {
        private EmpModel _emp;
        private List<EmpModel> _emplist;
        private List<dept> _deptlist;

        public InMemoryDBComp()
        {
            _emp = new EmpModel();
            _emplist = new List<EmpModel>();

            _emplist.Add(new EmpModel() { name = "rakesh", id = 101, salary = 200.36M, deptid = 201, gender = 1 });
            _emplist.Add(new EmpModel() { name = "ratnam", id = 102, salary = 250.00M, deptid = 201, gender = 1 });
            _emplist.Add(new EmpModel() { name = "haritha", id = 103, salary = 100.00M, deptid = 201, gender = 2 });
            _emplist.Add(new EmpModel() { name = "femi", id = 104, salary = 300.50M, deptid = 202, gender = 2 });
            _emplist.Add(new EmpModel() { name = "rony", id = 105, salary = 400.00M, deptid = 202, gender = 1 });
            
            _deptlist = new List<dept>();
            _deptlist.Add(new dept() { deptid = 201, deptname = "IT" });
            _deptlist.Add(new dept() { deptid = 202, deptname = "Sales" });

        }

        public EmpModel GetEmp(int id)
        {           
            return GetEmpList().Find((emp) => emp.id == id);
        }

        public List<EmpModel> GetEmpList()
        {
          
            return _emplist;
        }

        public void AddEmp(EmpModel emp)
        {
            bool isexistingrec = false;
            foreach (EmpModel rec in _emplist)
            {
                if (rec.id == emp.id)
                {
                    rec.salary = emp.salary;
                    isexistingrec = true;
                }
            }

            if (isexistingrec == false) { _emplist.Add(emp); }
            
        }

        public void UpdateEmp(EmpModel emp)
        {
           //EmpModel temp= _emplist.Find((rec) => rec.id == emp.id);
           // temp.salary = emp.salary;
            foreach(EmpModel rec in _emplist)
            {
                if (rec.id == emp.id)
                {
                    rec.salary = emp.salary;
                }
            }
        }

        public dept getdept(int id)
        {
            List<dept> deptList = new List<dept>();
            deptList=getdeptList();
            return deptList.Find((dept) => dept.deptid == id);
        }

        public List<dept> getdeptList()
        {
            return _deptlist;
        }



    }
}