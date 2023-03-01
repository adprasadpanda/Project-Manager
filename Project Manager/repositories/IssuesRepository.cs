using Microsoft.EntityFrameworkCore;
using Project_Manager.dbcontext;
using Project_Manager.models;

namespace Project_Manager.repositories
{
    public class IssuesRepository : IIssuesRepository
    {
        private readonly ProjectsContext projectsContext;

        public IssuesRepository(ProjectsContext projectsContext)
        {
            this.projectsContext = projectsContext;

        }

        public async Task<Issues> AddIssues(Guid projectId, Issues issues)
        {
            issues.issueId = new Guid();
            issues.projectId = projectId;

            await projectsContext.AddAsync(issues);
            await projectsContext.SaveChangesAsync();

            return issues;
        }

        public async Task<Issues> DeleteIssues(Guid projectId, Guid issueId)
        {
            var issues = await projectsContext.Issues.FirstOrDefaultAsync(x => x.issueId == issueId);
            return issues;

        }

        public async Task<IEnumerable<Issues>> GetAllIssues(Guid projectId)
        {
            List<Issues> listOfIssues = new List<Issues>();
            await foreach (var issue in projectsContext.Issues)
            {
                if(issue.projectId == projectId){
                    listOfIssues.Add(issue);
                }
                
            }

            return listOfIssues;
        }

        public async Task<Issues> GetIssues(Guid issueId)
        {

            var issues = await projectsContext.Issues.FirstOrDefaultAsync(x => x.issueId == issueId);
            return issues;
            
        }

        public async Task<Issues> UpdateIssue(Guid issueId, Issues issue)
        {
            var newIssue = await projectsContext.Issues.FirstOrDefaultAsync(x => x.projectId == issueId);

            if(newIssue == null){
                return null;
            }

            newIssue.status = issue.status;
            newIssue.type = issue.type;
            newIssue.title = issue.title;
            newIssue.description = issue.description;
            newIssue.reporter = issue.reporter;
            newIssue.assignee = issue.reporter;

            await projectsContext.SaveChangesAsync();
            return issue;
            
        }
    }

}