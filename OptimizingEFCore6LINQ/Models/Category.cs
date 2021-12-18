namespace EFCore6LINQBenchmarks.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public ICollection<BookCategory> BookCategories { get; set; }
    }
}
