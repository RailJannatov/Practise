using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practise.DataAccessLayer;
using Practise.ViewModels;

namespace Practise.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _dbContext;

        public HomeController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _dbContext.Categories.Where(x => x.IsMain && x.IsDeleted == false)
                .ToListAsync();

            return View(new HomeViewModel {Categories = categories});
        }
    }
}
