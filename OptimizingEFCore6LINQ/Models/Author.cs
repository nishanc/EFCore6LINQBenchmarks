namespace EFCore6LINQBenchmarks.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public AuthorBiography Biography { get; set; }
    }
}
