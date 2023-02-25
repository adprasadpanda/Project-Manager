using System.ComponentModel.DataAnnotations;
namespace Project_Manager.models
{
    public class Projects {

        [Key]
        public int projectId {get; set;}

        [Required]
        public string projectDescription {get; set;}
        
        [Required]
        public int creator {get; set;}

        public List<Issues> listOfIssues{get; set;}


    }
    
}