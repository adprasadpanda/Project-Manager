using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Project_Manager.models
{
    public class Issues {

        [Key]
        public Guid issueId {get; set;}

        [Required]
        public string status{get; set;}

        [Required]
        public string type{get; set;}

        [Required]
        public string title {get; set;}
        
        [Required]
        public string description {get; set;}

        [Required]
        public Guid reporter{get; set;}

        [Required]
        public Guid assignee{get; set;}

        [ForeignKey("projectId")]
        public Guid projectId {get; set;}
    }
    
}