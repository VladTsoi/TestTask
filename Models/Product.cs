namespace TestTask.Models
{
    public class Product
    {
        /// <summary>
        /// Id товара
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Название товара
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Категория товара(внешний ключ)
        /// </summary>
        public int CategoryId { get; set; }
        /// <summary>
        /// Связь с таблицей Categories
        /// </summary>
        public Category Category { get; set; } = new();
    }
}
