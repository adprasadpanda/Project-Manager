
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

        public async Task<Projects?> DeleteProject(Guid projectId)
        {
            var project = await projectsContext.Projects.FirstOrDefaultAsync(x => x.projectId == projectId);

            if(project == null){
                return null;
            }
            else {
                projectsContext.Projects.Remove(project);
                await projectsContext.SaveChangesAsync();

                return project;
            }
        }

        public async Task<Projects> UpdateProject(Guid projectId, Projects newProject)
        {
            var project = await projectsContext.Projects.FirstOrDefaultAsync(x => x.projectId == projectId);

            if(project == null){
                return project;
            }

            project.projectDescription = newProject.projectDescription;
            project.creator = newProject.creator;
            project.listOfIssues = newProject.listOfIssues;

            await projectsContext.SaveChangesAsync();
            return project;

        }
    }
}