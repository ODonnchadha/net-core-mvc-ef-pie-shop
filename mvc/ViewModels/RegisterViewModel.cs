using System.ComponentModel.DataAnnotations;

namespace mvc.ViewModels
{
    public class RegisterViewModel
    {
        [Required(), Display(Name = "User Name"), StringLength(26, ErrorMessage = "User Name is required")]
        public string UserName { get; set; }

        [Required(), DataType(DataType.Password), StringLength(60, ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
