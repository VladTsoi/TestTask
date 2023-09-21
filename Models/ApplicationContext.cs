using Microsoft.EntityFrameworkCore;

namespace TestTask.Models
{
    public class ApplicationContext : DbContext
    {
        /// <summary>
        /// Таблица продкутов
        /// </summary>
        public DbSet<Product> Products { get; set; } = null!;
        /// <summary>
        /// Таблица категорий
        /// </summary>
        public DbSet<Category> Categories { get; set; } = null!;
        /// <summary>
        /// Создание базы данных при первом обращении
        /// </summary>
        /// <param name="options"></param>
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
