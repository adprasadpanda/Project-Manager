using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Project_Manager.models
{
    public class Projects {

        [Key]
        public Guid projectId {get; set;}

        [Required]
        public string? projectDescription {get; set;}
        
        [Required]
        public Guid? creator {get; set;}

        public List<Issues>? listOfIssues{get; set;}

    }
    
}