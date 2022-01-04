using Class01.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Class01.IService
{
   public interface IVisitor
    {
        Task<Visitor> addVisitor(Visitor visitor);

        Visitor EditVisitor(int id, Visitor visitor);

        void DeleteVisitor(Visitor visitor);

      Task<Visitor> GetVisitor(int id);

        List<Visitor> Getall();


    }
}
