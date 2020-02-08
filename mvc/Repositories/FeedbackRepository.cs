using mvc.EF;
using mvc.Interfaces;
using mvc.Models;

namespace mvc.Repositories
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly AppDbContext context;

        public FeedbackRepository(AppDbContext context)
        {
            this.context = context;
        }
        public void AddFeedback(Feedback feedback)
        {
            this.context.Feedback.Add(feedback);
            this.context.SaveChanges();
        }
    }
}
