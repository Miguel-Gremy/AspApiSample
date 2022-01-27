using AspApiSample.API.Resources.Admin;
using AspApiSample.Lib.Models;
using AutoMapper;

namespace AspApiSample.API.Mappings
{
    public class AdminApiMapping : Profile
    {
        public AdminApiMapping()
        {
            CreateMap<UserCreateResource, User>()
                .ForMember(u => u.UserName, opt =>
                    opt.MapFrom(ur => ur.Email));
        }
    }
}
