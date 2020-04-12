using System;
using api.models;
using api.viewmodels;
using AutoMapper;


namespace api.services.Helper
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
