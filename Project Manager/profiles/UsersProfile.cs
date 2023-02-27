using AutoMapper;

namespace Project_Manager.profiles
{
    public class UsersProfile: Profile{
        public UsersProfile()
        {
            CreateMap<models.Users, models.dtos.Users>().ReverseMap();
        }
    }
    
}