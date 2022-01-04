using Class01.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Class01.IService
{
   public interface IMessagesService
    {
        Task<Messages> addMessage(Messages msg);
        List<Messages> getMessageForHer();
        List<Messages> getMessageForWife();
        List<Messages> getMessageForHusband();
        List<Messages> getMessageForHim();

        List<Messages> GetAll();
        Messages GetFeatured();
    }
}
