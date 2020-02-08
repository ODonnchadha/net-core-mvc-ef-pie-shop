using mvc.Models;
using System.Collections.Generic;

namespace mvc.Interfaces
{
    public interface IPieRepository
    {
        IEnumerable<Pie> GetAllPies();
        Pie GetPieById(int id);
    }
}
