using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Project_Manager.models.dtos
{
    public class Users
    {
        [Key]
        public Guid userId{get; set;}

        [Required]
        public string? userName{get; set;}

        public string? role{get; set;}

        [Required]
        public string? emailId{get; set;}

        [Required]
        public string? password {get; set;}

        public List<Issues>? reporterOfIssues{get; set;}
        
        public List<Issues>? assignedIssues{get; set;}


    }
    
}