using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_Manager.models.dtos
{
    public class Projects
    {
        

        [Key]
        public Guid projectId {get; set;}

        [Required]
        public string projectDescription {get; set;}
        
        [Required]
        public Guid creator {get; set;}
        
        public List<Issues> listOfIssues{get; set;}


    
    }
}