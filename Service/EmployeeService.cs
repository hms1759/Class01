

using Class01.IService;
using Class01.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Class01.Service
{
    public class EmployeeService : IEmployee
    {
        private EmployeeDbContext _dbContext;
        public EmployeeService(EmployeeDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Employee addEmployee(Employee employee)
        {
            var found = _dbContext.EmployeeTable.SingleOrDefault(x=> x.Email == employee.Email);
            if(found!=null)
            {
                return (null);
            }
            _dbContext.EmployeeTable.Add(employee);
            _dbContext.SaveChanges();
            return (employee);
        }

        public void DeleteEmployee(Employee emp)
        {
            _dbContext.EmployeeTable.Remove(emp);
            _dbContext.SaveChanges();
           
        }

        public Employee EditEmployee(int id,Employee employee)
        {
            var Found = _dbContext.EmployeeTable.SingleOrDefault(x => x.Id == id);


            Found.Id = Found.Id;
            Found.Name = employee.Name;
            Found.Email = employee.Email;
            Found.Phone = employee.Phone;
            _dbContext.EmployeeTable.Update(Found);
            _dbContext.SaveChanges();
               
            return Found;


        }

        public List<Employee> Getall()
        {
            var allEmployees = _dbContext.EmployeeTable.ToList();
            return (allEmployees);
                
        }

        public async Task<Employee> GetEmployee(int id)
        {
           var employee = _dbContext.EmployeeTable.SingleOrDefault(x => x.Id == id);
            return employee;
        }

      
    }
}
