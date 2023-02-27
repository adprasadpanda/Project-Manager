
using Microsoft.EntityFrameworkCore;
using Project_Manager.dbcontext;
using Project_Manager.models;

namespace Project_Manager.repositories
{
    public class ProjectsRepository : IProjectsRepository
    {
        private readonly ProjectsContext projectsContext;

        public ProjectsRepository(ProjectsContext projectsContext)
        {
            this.projectsContext = projectsContext;

        }

        public async Task<IEnumerable<Projects>> GetAllProjects()
        {
            return await projectsContext.Projects.ToListAsync();
        }

        public async Task<Projects> GetProject(Guid projectId)
        {
            try
            {
                var project = await projectsContext.Projects.FirstOrDefaultAsync(x => x.projectId == projectId);
                return project;
            }
            catch (System.Exception)
            {
                throw;
            }
        }


        public async Task<Projects> AddProjects(Projects projects)
        {
            projects.projectId = new Guid();
            await projectsContext.AddAsync(projects);
            await projectsContext.SaveChangesAsync();

            return projects;
        }
    }
}