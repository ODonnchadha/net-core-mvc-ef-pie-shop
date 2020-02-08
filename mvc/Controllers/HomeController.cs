using Microsoft.AspNetCore.Mvc;
using mvc.Interfaces;
using mvc.ViewModels;
using System.Linq;

namespace mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPieRepository pieRepository;

        public HomeController(IPieRepository pieRepository)
        {
            this.pieRepository = pieRepository;
        }

        [HttpGet()]
        public IActionResult Index()
        {
            return View(new HomeViewModel
            {
                Title = "Overview",
                Pies = this.pieRepository.GetAllPies().OrderBy(
                    p => p.Name).ToList()
            });
        }

        [HttpGet()]
        public IActionResult Details(int id)
        {
            var pie = this.pieRepository.GetPieById(id);
            if (pie == null) return NotFound();

            return View(new DetailViewModel
            {
                Title = pie.Name,
                Pie = pie
            });
        }
    }
}
