using AutoMapper;

namespace picpay;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserDTO>();
        CreateMap<UserCreateDTO, User>();
        CreateMap<UserUpdateDTO, User>();
        CreateMap<Transaction, TransactionDTO>();
        CreateMap<Transaction, TransactionDTO>()
            .ForMember(dest => dest.User, opt => opt.MapFrom((src, dest, destMember, context) =>
            {
                return
                    src.PayerId == (Guid)context.Items["id"] ?
                    src.Payee?.GetFullName() :
                    src.Payer?.GetFullName();
            }))
            .ForMember(dest => dest.Value, opt => opt.MapFrom((src, dest, destMember, context) =>
            {
                return
                    src.PayerId == (Guid)context.Items["id"] ?
                    src.Value * -1 :
                    src.Value;
            }));
    }
}
