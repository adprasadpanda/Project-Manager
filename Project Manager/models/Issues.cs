using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Project_Manager.models
{
    public class Issues {

        [Key]
        public int id {get; set;}

        [Required]
        public string title {get; set;}
        
        [Required]
        public string description {set; get;}

        [Required]
        public int reporter{set; get;}

        [Required]
        public int assignee {set; get;}

        [ForeignKeyAttribute("projectId")]
        public int projectId {get; set;}
    }
    
}