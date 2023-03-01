using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project_Manager.models;
using Project_Manager.repositories;

namespace Project_Manager.Controllers
{
    public class IssuesController: Controller 
    {
        private readonly IIssuesRepository issuesRepository;
        private readonly IMapper mapper;

        public IssuesController(IIssuesRepository issuesRepository, IMapper mapper)
        {
            this.issuesRepository = issuesRepository;
            this.mapper = mapper;

        }

        [HttpGet]
        [Route("getallissues/{id:guid}")]
        public async Task<IActionResult> GetAllIssues([FromRoute]Guid proectId)
        {
            var result = await issuesRepository.GetAllIssues(proectId);
            
            if(result == null) {
                return NotFound();
            }
            return Ok(result);

        }

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetProject")]
        public async Task<IActionResult> GetIssue(Guid id)
        {
            var issue = await issuesRepository.GetIssues(id);
            

            if (issue == null)
            {

                return NotFound();
            }
            else
            {
                return Ok(issue);
            }
        }

        [HttpPost]
        [Route("{id:guid}")]
        public async Task<ActionResult<Issues>> AddIssue([FromRoute]Guid projectId, [FromBody]models.dtos.AddIssueRequest addIssueRequest)
        {
            var newIssue = new Issues(){
                issueId = new Guid(),
                status = addIssueRequest.status,
                title = addIssueRequest.title,
                description = addIssueRequest.description,
                reporter = addIssueRequest.reporter,
                assignee = addIssueRequest.assignee,
                projectId = projectId
            };
        

            newIssue = await issuesRepository.AddIssues(projectId, newIssue);

            return Ok(newIssue);

        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteIssue(Guid projectId, Guid issueId) {
            var issue = await issuesRepository.DeleteIssues(projectId, issueId);

            return Ok(issue);
        }

        [HttpPut]
        [Route("{projectId:guid}/{issuerId:guid}")]
        public async Task<ActionResult<Users>> UpdateIssue([FromRoute]Guid issueId, [FromBody]models.dtos.AddIssueRequest addIssueRequest)
        {
            var newIssue = new models.Issues() {
                status = addIssueRequest.status,
                type = addIssueRequest.type,
                title = addIssueRequest.title,
                description = addIssueRequest.description,
                reporter = addIssueRequest.reporter,
                assignee = addIssueRequest.reporter,
            };
            
            newIssue = await issuesRepository.UpdateIssue(issueId, newIssue);
            
            return Ok(newIssue);

        }





        
    }
    
}