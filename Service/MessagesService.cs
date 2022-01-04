using AutoMapper;
using Class01.IService;
using Class01.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Class01.Service
{
    public class MessagesService : IMessagesService
    {

        private HotelMSDBContext _dbContext;

        private readonly IMapper _mapper;
        public MessagesService(HotelMSDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

       public async Task<Messages> addMessage(Messages msg)
        {
            var Message = _mapper.Map<Messages>(msg);

            _dbContext.DbMessages.Add(Message);
            int count = _dbContext.SaveChanges();
            if (count < 1)
            {
                return null;

            }

            return (Message);
        }

        public List<Messages> getMessageForHer()
        {
            var hermsg = _dbContext.DbMessages.Where(x => x.title.Contains("her")).ToList();
            return hermsg;
        }

        public List<Messages> getMessageForWife()
        {
            throw new NotImplementedException();
        }

        public List<Messages> getMessageForHusband()
        {
            throw new NotImplementedException();
        }

        public List<Messages> getMessageForHim()
        {
            throw new NotImplementedException();
        }

        public Messages GetFeatured()
        {
            var random = new Random();
            var featuredmsg = _dbContext.DbMessages.Where(x => x.feature == Enum.Featured.True).ToList();
            int i = random.Next(featuredmsg.Count);
            var msg = featuredmsg[i];
            return msg;
        }

        public List<Messages> GetAll()
        {
            throw new NotImplementedException();
        }

       
    }
}
