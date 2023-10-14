using AutoMapper;

namespace picpay;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserDTO>();
        CreateMap<UserCreateDTO, User>();
    }
}
