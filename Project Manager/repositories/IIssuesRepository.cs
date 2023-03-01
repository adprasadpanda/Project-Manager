using Project_Manager.models;

namespace Project_Manager.repositories
{
    public interface IIssuesRepository 
    {

        Task <IEnumerable<Issues>> GetAllIssues(Guid projectId);
        Task<Issues> GetIssues(Guid issueId);

        Task<Issues> AddIssues(Guid projectId, Issues issues);

        Task<Issues> DeleteIssues(Guid projectId, Guid issueId);

        Task<Issues> UpdateIssue(Guid issueId, Issues issues);
        
    }
    
}