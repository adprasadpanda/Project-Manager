using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_Manager.models.dtos
{
    public class AddUsersRequest 
    {
        [Required]
        public string? userName{get; set;}

        public string? role{get; set;}

        [Required]
        public string? emailId{get; set;}

        [Required]
        public string? password{get; set;}

        
        public List<Issues>? reporterOfIssues{get; set;}
        
        public List<Issues>? assignedIssues{get; set;}

    }
    
}