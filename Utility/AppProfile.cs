using Class01.Model;
using Class01.Models;
using Class01.VeiwModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApplication.Utility
{
    public class AppProfile : AutoMapper.Profile
    {
        public AppProfile()
        {
            CreateMap<Staffs, staffsViewModel>()
                .ReverseMap();

            CreateMap<Staffs, StaffViewModel>()
                .ReverseMap();
            CreateMap<Staffs, staffUpdateViewModel>()
                .ReverseMap();
            CreateMap<Visitor, VisitorViewModel>()
                .ReverseMap();
            CreateMap<Order, OrderViewModel>()
                .ReverseMap();
            CreateMap<Messages, MessagesViewModel>()
                .ReverseMap();
        }
    }
}
