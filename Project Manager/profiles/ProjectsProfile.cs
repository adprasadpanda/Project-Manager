using AutoMapper;

namespace Project_Manager.profiles
{
    public class ProjectsProfile: Profile{
        public ProjectsProfile()
        {
            CreateMap<models.Projects, models.dtos.Projects>().ReverseMap();
            
        }
    }
    
}