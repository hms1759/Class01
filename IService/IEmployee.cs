using Class01.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Class01.IService
{
   public interface IEmployee
    {
        Employee addEmployee(Employee employee);

        Employee EditEmployee(int id, Employee employee);

        void DeleteEmployee(Employee employee);

      Task<Employee> GetEmployee(int id);

        List<Employee> Getall();


    }
}
