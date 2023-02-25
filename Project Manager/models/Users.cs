using System.ComponentModel.DataAnnotations;

namespace Project_Manager.models 
{
    public class Users{
        
        [Key]
        public int userId{set; get;}

        [Required]
        public string userName{set; get;}

    }


}