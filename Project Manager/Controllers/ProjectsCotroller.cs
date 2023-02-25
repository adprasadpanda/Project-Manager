using Microsoft.AspNetCore.Mvc;
using Project_Manager.models;

namespace  Project_Manager.Controllers
{
    [ApiController]
    [Route("projects")]
    public class ProjectManagerController: Controller {
        
        [HttpGet]
        public IActionResult getAllProjects() {
            
            var projects = new List<Projects>()
            {
                new Projects
                {
                    projectId=1,
                    projectDescription="First project with description",
                    creator=1,
                    listOfIssues= new List<Issues>(){
                        new Issues(){
                            issueId=1,
                            status="Open",
                            type="Epic",
                            title="First Issue",
                            description="First issue of first project",
                            reporter=1,
                            assignee=2,
                            projectId=1
                        },
                        new Issues(){
                            issueId=1,
                            status="On Review",
                            type="Story",
                            title="Second Issue",
                            description="Second issue of first project",
                            reporter=1,
                            assignee=2,
                            projectId=1
                        },
                        new Issues(){
                            issueId=1,
                            status="QA Testing",
                            type="Bug",
                            title="Third Issue",
                            description="Third issue of first project",
                            reporter=1,
                            assignee=2,
                            projectId=1
                        },
                    }




                },
                new Projects
                {
                    projectId=2,
                    projectDescription="Second project with description",
                    creator=2,
                    listOfIssues= new List<Issues>(){
                        new Issues(){
                            issueId=1,
                            status="Open",
                            type="Epic",
                            title="First Issue",
                            description="First issue of second project",
                            reporter=1,
                            assignee=2,
                            projectId=1
                        },
                        new Issues(){
                            issueId=1,
                            status="On Review",
                            type="Story",
                            title="Second Issue",
                            description="Second issue of second project",
                            reporter=1,
                            assignee=2,
                            projectId=1
                        },
                        new Issues(){
                            issueId=1,
                            status="QA Testing",
                            type="Bug",
                            title="Third Issue",
                            description="Third issue of second project",
                            reporter=1,
                            assignee=2,
                            projectId=1
                        },
                    }


                }  

            };

            return Ok(projects);

        }
        
    }
    
}