using mvc.Models;

namespace mvc.Interfaces
{
    public interface IFeedbackRepository
    {
        void AddFeedback(Feedback feedback);
    }
}
