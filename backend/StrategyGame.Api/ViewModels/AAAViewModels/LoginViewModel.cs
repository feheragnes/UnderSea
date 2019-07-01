using System.ComponentModel.DataAnnotations;

namespace StrategyGame.Api.ViewModels.AAAViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
