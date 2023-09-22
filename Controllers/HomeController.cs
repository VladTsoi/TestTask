using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestTask.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace TestTask.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>Контекст базы данных </summary>
        ApplicationContext db;
        public HomeController(ApplicationContext context)
        {
            db = context;
            ///<summary>Наполняю таблицы разными данными </summary>
            if (!db.Categories.Any())
            {
                Category food = new Category { Name = "Еда" };
                Category electronic = new Category { Name = "Электроника" };
                Category cosmetics = new Category { Name = "Косметика" };
                Category stationery = new Category { Name = "Канцтовары" };

                Product Product1 = new Product { Name = "Мороженное", Category = food };
                Product Product2 = new Product { Name = "Тирамису", Category = food };
                Product Product3 = new Product { Name = "Телевизор", Category = electronic };
                Product Product4 = new Product { Name = "Утюг", Category = electronic };
                Product Product5 = new Product { Name = "Помада", Category = cosmetics };
                Product Product6 = new Product { Name = "Крем для рук", Category = cosmetics };
                Product Product7 = new Product { Name = "Ручка шариковая", Category = stationery };
                Product Product8 = new Product { Name = "Линейка", Category = stationery };

                db.Categories.AddRange(food, electronic, cosmetics, stationery);
                db.Products.AddRange(Product1, Product2, Product3, Product4, Product5, Product6, Product7, Product8);
                db.SaveChanges();
            }
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