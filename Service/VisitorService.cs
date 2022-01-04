

using AutoMapper;
using Class01.IService;
using Class01.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Class01.Service
{
    public class VisitorService : IVisitor
    {
        private HotelMSDBContext _dbContext;

        private readonly IMapper _mapper;
        public VisitorService(HotelMSDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;

            _mapper = mapper;
        }
        public async Task<Visitor> addVisitor(Visitor visit)
        {
            var visitor = _mapper.Map<Visitor>(visit);

            _dbContext.DbVisitor.Add(visitor);
          int count =  _dbContext.SaveChanges();
            if (count < 1)
            {
            return null;
             
            }

            return (visitor);  
        }

        public void DeleteVisitor(Visitor visitor)
        {
            _dbContext.DbVisitor.Remove(visitor);
            _dbContext.SaveChanges();
           
        }

        public Visitor EditVisitor(int id, Visitor visitor)
        {
            var Found = _dbContext.DbVisitor.FirstOrDefault(x => x.Id == id);


            Found.Id = Found.Id;
            Found.Name = visitor.Name;
            Found.Email = visitor.Email;
            Found.Phone = visitor.Phone;
            _dbContext.DbVisitor.Update(Found);
            _dbContext.SaveChanges();
               
            return Found;


        }

        public List<Visitor> Getall()
        {
            var allvisitors = _dbContext.DbVisitor.ToList();
            return (allvisitors);
                
        }

        public async Task<Visitor> GetVisitor(int id)
        {
           var employee = _dbContext.DbVisitor.SingleOrDefault(x => x.Id == id);
            return employee;
        }

      
    }
}
