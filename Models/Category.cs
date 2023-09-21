namespace TestTask.Models
{
    public class Category
    {
        /// <summary>
        /// Id категории
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Название категории
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Связь с таблицы Products
        /// </summary>
        public List<Product>? Products { get; set; }
    }
}
