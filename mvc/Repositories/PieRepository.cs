using mvc.EF;
using mvc.Interfaces;
using mvc.Models;
using System.Collections.Generic;
using System.Linq;

namespace mvc.Repositories
{
    public class PieRepository : IPieRepository
    {
        private readonly AppDbContext context;

        public PieRepository(AppDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<Pie> GetAllPies()
        {
            return this.context.Pies;
        }

        public Pie GetPieById(int id)
        {
            return this.context.Pies.FirstOrDefault(p => p.Id == id);
        }
    }
}
