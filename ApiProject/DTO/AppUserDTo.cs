using System.ComponentModel.DataAnnotations;

namespace ApiProject.DTO
{
    public class AppUserDTo
    {
        [Required]
        public string UserName { set; get;  }
        [Required]
        public string Password { set; get; }
        [Required]
        public string CheckPassword { set; get;  }
    }
}
