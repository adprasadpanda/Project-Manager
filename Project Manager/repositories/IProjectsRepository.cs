using Project_Manager.models;

namespace Project_Manager.repositories
{
    public interface IProjectsRepository
    {
        Task <IEnumerable<Projects>> GetAllProjects();

        Task<Projects> GetProject(Guid id);

        Task<Projects> AddProjects(Projects projects);

        Task<Projects> DeleteProject(Guid id);

        Task<Projects> UpdateProject(Guid id, Projects projects);
    }
}