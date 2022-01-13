using AspApiSample.API.Resources.Auth;
using AspApiSample.Lib.Models;
using AutoMapper;

namespace AspApiSample.API.Mappings
{
    public class AuthApiMapping : Profile
    {
        public AuthApiMapping()
        {
            CreateMap<UserSignUpResource, User>()
                .ForMember(u => u.UserName, opt =>
                    opt.MapFrom(ur => ur.Email));
        }
    }
}