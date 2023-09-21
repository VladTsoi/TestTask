using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestTask.Models;

namespace TestTask.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>Контекст базы данных </summary>
        ApplicationContext db;
        public HomeController(ApplicationContext context)
        {
            db = context;
        }
        /// <summary>Вывод на web-страницу данных двух таблиц</summary>
        public async Task<IActionResult> Index()
        {
            var products = db.Products.Join(db.Categories,
                p => p.CategoryId,
                c => c.Id,
                (p, c) => new ProductsCategories
                {
                    Id = p.Id,
                    Name = p.Name,
                    Category = c.Name
                });
            return View(await products.ToListAsync());
        }
    }
}