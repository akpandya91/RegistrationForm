using AutoMapper;
using VoingPracticalTestAPI.Models;
using VoingPracticalTestData.Models;

namespace VoingPracticalTestAPI.Automapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserDetail, User_Register>();
            CreateMap<User_Register, UserDetail>();
        }
    }
}
