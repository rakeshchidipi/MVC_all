using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC_all.Models;

namespace MVC_all.Comp
{
   public interface IDBComp
    {
        EmpModel GetEmp(int id);
        List<EmpModel> GetEmpList();
        dept getdept(int id);
        List<dept> getdeptList();
        void AddEmp(EmpModel emp);
        void UpdateEmp(EmpModel emp);
    }
}
