using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practise.DataAccessLayer;
using Practise.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practise.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AppDbContext _dbContext;

        public CategoryController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index(int? id)
        {
            if (id == null)
                return NotFound();

            var category = await _dbContext.Categories.FirstOrDefaultAsync(x => x.IsDeleted == false && x.Id == id);
            if (category == null)
                return NotFound();

            var categories = await _dbContext.Categories.Where(x => x.IsDeleted == false && x.IsMain)
                .Include(x => x.Children.Where(y => y.IsDeleted == false)).ToListAsync();

            return View(new CategoryViewModel 
            {
                Category = category,
                Categories = categories
            });
        }
    }
}
