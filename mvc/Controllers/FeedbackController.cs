using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using mvc.Interfaces;
using mvc.ViewModels;

namespace mvc.Controllers
{
    [Authorize()]
    public class FeedbackController : Controller
    {
        private readonly IFeedbackRepository feedbackRepository;
        public FeedbackController(IFeedbackRepository feedbackRepository)
        {
            this.feedbackRepository = feedbackRepository;
        }

        [HttpGet()]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost()]
        public IActionResult Index(FeedbackViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                this.feedbackRepository.AddFeedback(
                    new Models.Feedback
                    {
                        ContactMe = viewModel.ContactMe,
                        Email = viewModel.Email,
                        Message = viewModel.Message,
                        Name = viewModel.Name
                    });

                return RedirectToAction("Complete");
            }

            return View(viewModel);
        }

        [HttpGet()]
        public IActionResult Complete()
        {
            return View();
        }
    }
}
