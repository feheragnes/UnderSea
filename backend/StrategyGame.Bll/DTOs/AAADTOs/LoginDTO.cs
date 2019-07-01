using System.ComponentModel.DataAnnotations;

namespace StrategyGame.Bll.DTOs.AAADTOs
{
    public class LoginDTO
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
