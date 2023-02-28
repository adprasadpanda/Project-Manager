using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project_Manager.models;
using Project_Manager.repositories;

namespace Project_Manager.Controllers
{
    [ApiController]
    [Route("projects")]
    public class ProjectsController : Controller
    {
        private readonly IProjectsRepository projectsRepository;
        private readonly IMapper mapper;

        public ProjectsController(IProjectsRepository projectsRepository, IMapper mapper)
        {
            this.projectsRepository = projectsRepository;
            this.mapper = mapper;

        }

        // Method to get all the projects present in repo
        [HttpGet]
        [Route("getallprojects")]
        public async Task<IActionResult> GetAllProjects()
        {
            var result = await projectsRepository.GetAllProjects();
            var projectDTO = mapper.Map<List<models.dtos.Projects>>(result);
            
            if(projectDTO == null) {
                return NotFound();
            }
            return Ok(projectDTO);

        }


        // Method to get a single project by id
        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetProject")]
        public async Task<IActionResult> GetProject(Guid id)
        {
            var project = await projectsRepository.GetProject(id);
            var response = mapper.Map<models.dtos.Projects>(project);

            if (response == null)
            {

                return NotFound();
            }
            else
            {
                return Ok(response);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Projects>> AddProject(models.dtos.AddProjectRequest addProjectRequest)
        {
            var newProject = new Projects()
            {
                projectDescription = addProjectRequest.projectDescription,
                creator = addProjectRequest.creator,

            };

            newProject = await projectsRepository.AddProjects(newProject);

            var projectsDTO = new models.dtos.Projects() 
            {
                projectId = newProject.projectId,
                projectDescription = newProject.projectDescription,
                creator = newProject.creator,
                listOfIssues = newProject.listOfIssues
            };

            // return CreatedAtAction(nameof(GetProject), new {projectId = newProject.projectId}, projectsDTO);

            return Ok(projectsDTO);

        }
        
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteProject(Guid projectId) {
            var project = await projectsRepository.DeleteProject(projectId);

            if(project == null){
                return NotFound();
            }

            var projectDTO = new models.dtos.Projects(){
                projectId = project.projectId,
                projectDescription = project.projectDescription,
                creator = project.creator,
                listOfIssues = project.listOfIssues
            };

            return Ok(project);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<ActionResult<Projects>> UpdateProject([FromBody]models.dtos.UpdateProjectRequest updateProjectRequest, [FromRoute]Guid projectId)
        {
            var newProject = new models.Projects()
            {
                projectDescription = updateProjectRequest.projectDescription,
                creator = updateProjectRequest.creator

            };

            newProject = await projectsRepository.UpdateProject(projectId, newProject);

            if(newProject == null){
                return NotFound();
            }

            var projectsDTO = new models.dtos.Projects() 
            {
                projectId = newProject.projectId,
                projectDescription = newProject.projectDescription,
                creator = newProject.creator,
                listOfIssues = newProject.listOfIssues
            };

            return Ok(projectsDTO);

        }

    }


}