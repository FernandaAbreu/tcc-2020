using System;
using AutoMapper;
using domain.models;
using viewmodels;

namespace services.Helper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, VMClient>();
            CreateMap<User, VMInstructor>();
            CreateMap<Instructor, VMInstructor>();
            CreateMap<Client, VMClient>();
            CreateMap<User, VMLoginResponse>();
        }
        
        //CreateMap<User, VMClient>();
    }
}
