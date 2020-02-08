using System.ComponentModel.DataAnnotations;

namespace mvc.ViewModels
{
    public class FeedbackViewModel
    {
        [Required(), StringLength(100, ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(), StringLength(100, ErrorMessage = "Email is required"), DataType(DataType.EmailAddress, ErrorMessage = "Email is invalid")]
        public string Email { get; set; }

        [Required(), StringLength(5000, ErrorMessage = "Message is required")]
        public string Message { get; set; }

        public bool ContactMe { get; set; }
    }
}
