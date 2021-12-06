using Class01.IService;
using Class01.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Class01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private IEmployee _employee;
        private EmployeeDbContext _dbcontex;
        public EmployeesController(IEmployee employee, EmployeeDbContext dbcontex)
        {
            _employee = employee;
            _dbcontex = dbcontex;

        }
        [HttpGet]
        [Route("Employees")]
        public ActionResult<IEnumerable<Employee>> GetallEmployee()
        {
            var employees = _employee.Getall();
            if (employees == null)
            {
                return BadRequest("Empty List");
            }
            return Ok(employees);
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = await _employee.GetEmployee(id);
            if (employee == null)
            {
                return BadRequest("Empty List");
            }

            return Ok(employee);
        }


        [HttpPost]
        [Route("Add")]
        public ActionResult<Employee> AddEmployee(Employee employee)
        {

            var Emp = _employee.addEmployee(employee);

            if (Emp == null)
            {
                return BadRequest("Employee already exist");
            }


            return Ok(Emp);
        }


        [HttpDelete]
        [Route("{id}")]
        public ActionResult<Employee> DeleteEmployee(int id)
        {
            var emp = _dbcontex.EmployeeTable.SingleOrDefault(x => x.Id == id);
            if (emp == null)
            {
                return BadRequest("Not Found");
            }

            _employee.DeleteEmployee(emp);
            return Ok("Deleted ");
        }

        [HttpPatch]
        [Route("{id}")]
        public ActionResult<Employee> Edit(int id, Employee emp)
        {

            var found = _dbcontex.EmployeeTable.SingleOrDefault(x => x.Id == id);
            if(found != null)
            {
               
               var edit= _employee.EditEmployee(id, emp);

                return Ok(edit);
            }

           
            return BadRequest("Not Found");
        }


    }
}
