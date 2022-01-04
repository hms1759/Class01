using Class01.IService;
using Class01.Model;
using Microsoft.AspNetCore.Mvc;
using MyApplication.validation;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Class01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitorController : ControllerBase
    {
        private IVisitor _visitor;
        private HotelMSDBContext _dbcontex;
        public VisitorController(IVisitor visitor, HotelMSDBContext dbcontex)
        {
            _visitor = visitor;
            _dbcontex = dbcontex;

        }
        [HttpGet]
        [Route("Visitor")]
        public ActionResult<IEnumerable<Visitor>> GetallVisitor()
        {
            var visitor = _visitor.Getall();
            if (visitor == null)
            {
                return BadRequest("Empty List");
            }
            return Ok(visitor);
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Visitor>> GetVisitor(int id)
        {
            var employee = await _visitor.GetVisitor(id);
            if (employee == null)
            {
                return BadRequest("Empty List");
            }

            return Ok(employee);
        }


        [HttpPost]
        [Route("Add")]
        public async Task<ActionResult<Visitor>> AddVisitor(Visitor visitor)
        {

            var check = _dbcontex.DbVisitor.FirstOrDefault(x => x.Email == visitor.Email);
           //var check =await _dbcontex.DbVisitor.FindAsync(visitor.Email).;
            if (check != null)
            {
                return BadRequest("emaill is already in use");
            }

            var validPhone = Regex.IsMatch(visitor.Phone, Validation.IsPhoneNumber) || Regex.IsMatch(visitor.Phone, Validation.IsPhoneNumberAlt);
            if (validPhone != true)
            {

                return BadRequest("input a valid Phone number");
            }

            var validEmail = Regex.IsMatch(visitor.Email, Validation.IsEmail);
            if (validEmail != true)
            {

                return BadRequest("input a valid Email");
            }


            var visit = _visitor.addVisitor(visitor);

            if (visit == null)
            {
                return BadRequest("Error Occur");
            }


            return Ok(visit);
        }


        [HttpDelete]
        [Route("{visitorid}")]
        public  ActionResult<Visitor> DeleteVisitor(int id)
        {
            var emp = _dbcontex.DbVisitor.FirstOrDefault(x => x.Id == id);
            if (emp == null)
            {
                return BadRequest("Not Found");
            }

            _visitor.DeleteVisitor(emp);
            return Ok("Deleted ");
        }

        [HttpPatch]
        [Route("{visitorid}")]
        public ActionResult<Visitor> Edit(int id, Visitor visitor)
        {

            var found = _dbcontex.DbVisitor.FirstOrDefault(x => x.Id == id);
            if(found != null)
            {
               
               var edit= _visitor.EditVisitor(id, visitor);

                return Ok(edit);
            }

           
            return BadRequest("Not Found");
        }


    }
}
