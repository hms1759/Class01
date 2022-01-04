using Class01.IService;
using Class01.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Class01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private IMessagesService _imsg;
        private HotelMSDBContext _dbcontex;
        public MessagesController(IMessagesService imsg, HotelMSDBContext dbcontex)
        {
            _imsg = imsg;
            _dbcontex = dbcontex;

        }
        [HttpGet]
        [Route("Messages")]
        public ActionResult<IEnumerable<Messages>> GetallMessage()
        {
            var msg = _imsg.GetAll();
            if (msg == null)
            {
                return BadRequest("Empty List");
            }
            return Ok(msg);
        }

        [HttpGet]
        [Route("HerMessages")]
        public ActionResult<IEnumerable<Messages>> GetHerMsgs()
        {
            var msg = _imsg.getMessageForHer();
            if (msg == null)
            {
                return BadRequest("Empty List");
            }
            return Ok(msg);
        }

        [HttpGet]
        [Route("Featured")]
        public ActionResult<Messages> GetFeatured()
        {
            var msg = _imsg.GetFeatured();
            if (msg == null)
            {
                return BadRequest("Empty List");
            }
            return Ok(msg);
        }


        [HttpPost]
        [Route("Add")]
        public async Task<ActionResult<Messages>> AddMessage(Messages msg)
        {


            var visit = _imsg.addMessage(msg);

            if (visit == null)
            {
                return BadRequest("Error Occur");
            }


            return Ok(visit);
        }

    }

}
