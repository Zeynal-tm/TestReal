using AutoMapper;
using TestReal.Persistence.Domain;
using TestReal.Services.Interfaces.Dtos;
using TestReal.Services.Interfaces.ViewModels;

namespace TestReal.Services.MappingProfile
{
    public class UserRegistrationMappingProfile : Profile
    {
        public UserRegistrationMappingProfile()
        {
            CreateMap<CreateUserRegistrationViewModel, UserRegistration>().ReverseMap();
            CreateMap<UpdateUserRegistrationViewModel, UserRegistration>().ReverseMap();
            CreateMap<UserRegistration, UserRegistrationDto>().ReverseMap();
        }
    }
}