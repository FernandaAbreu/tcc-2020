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
            CreateMap<VMClient, User>();
            CreateMap<VMInstructor, User>();
            CreateMap<User, VMInstructor>();
            CreateMap<VMInstructor, Instructor>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.id));
            CreateMap<Instructor, VMInstructor>().ForMember(dest => dest.id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.User.Name))
                .ForMember(dest => dest.cpf, opt => opt.MapFrom(src => src.User.Cpf))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User.Email))
            .ForMember(dest => dest.RG, opt => opt.MapFrom(src => src.User.Rg))
            .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.User.Password));
            CreateMap<VMClient, Client>();
            CreateMap<Client, VMClient>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.User.Name))
                .ForMember(dest => dest.cpf, opt => opt.MapFrom(src => src.User.Cpf))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User.Email))
            .ForMember(dest => dest.RG, opt => opt.MapFrom(src => src.User.Rg))
            .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.User.Password));
            CreateMap<User, VMLoginResponse>();
            CreateMap<City, VMCity>();

        }
        
        //CreateMap<User, VMClient>();
    }
}
