using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Project_Manager.models
{
    public class Issues {

        [Key]
        public int issueId {get; set;}

        [Required]
        public string status{get; set;}

        [Required]
        public string type{get; set;}

        [Required]
        public string title {get; set;}
        
        [Required]
        public string description {get; set;}

        [Required]
        public int reporter{get; set;}

        [Required]
        public int assignee {get; set;}

        [ForeignKeyAttribute("projectId")]
        public int projectId {get; set;}
    }
    
}