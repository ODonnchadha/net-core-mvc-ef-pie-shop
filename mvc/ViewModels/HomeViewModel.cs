using mvc.Models;
using System.Collections.Generic;

namespace mvc.ViewModels
{
    public class HomeViewModel
    {
        public string Title { get; set; }
        public List<Pie> Pies { get; set; }
    }
}
