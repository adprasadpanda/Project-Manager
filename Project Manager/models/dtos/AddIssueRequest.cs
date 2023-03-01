using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace  Project_Manager.models.dtos
{
    public class AddIssueRequest 
    {
        [Required]
        public string? status{get; set;}

        [Required]
        public string? type{get; set;}

        [Required]
        public string? title {get; set;}
        
        [Required]
        public string? description {get; set;}

        
        public Guid reporter{get; set;}

        
        public Guid assignee{get; set;}

        [ForeignKey("projectId")]
        public Guid projectId {get; set;}

    }
    
}