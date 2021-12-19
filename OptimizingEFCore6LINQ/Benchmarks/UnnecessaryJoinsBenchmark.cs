using BenchmarkDotNet.Attributes;
using Microsoft.EntityFrameworkCore;

namespace EFCore6LINQBenchmarks.Benchmarks
{
    [MemoryDiagnoser]
    public class UnnecessaryJoinsBenchmark : Benchmark
    {
        [Benchmark]
        public async Task<List<CustomView>> WithJoins()
        {

            var books = await (from authors in Context.Authors
                where authors.Id > 5
                join book in Context.Books on authors.Id equals book.AuthorId select book)
                .Select(x => new CustomView
            {
                Title = x.Title,
                AuthorFirstName = x.Author.FirstName
            }).ToListAsync();

            return books;
        }

        [Benchmark]
        public async Task<List<CustomView>> WithoutJoins()
        {

            var authors1 = await (from author in Context.Authors where author.Id > 5 select author).Select(x => x).ToListAsync();
            var books = await (from book in Context.Books where authors1.Contains(book.Author) select book)
                .Select(x => new CustomView
            {
                Title = x.Title,
                AuthorFirstName = x.Author.FirstName
            }).ToListAsync();

            return books;
        }

        public class CustomView
        {
            public string Title { get; set; }
            public string AuthorFirstName { get; set; }
        }
    }
}
