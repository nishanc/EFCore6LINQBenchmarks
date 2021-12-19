using BenchmarkDotNet.Attributes;
using Microsoft.EntityFrameworkCore;
using EFCore6LINQBenchmarks.Models;

namespace EFCore6LINQBenchmarks.Benchmarks
{
    [MemoryDiagnoser]
    public class MultipleIncludeBenchmark : Benchmark
    {
        [Benchmark]
        public async Task<List<Book>> MultipleIncludeChain()
        {
            return await Context.Books
                .Include(x => x.BookCategories)
                    .ThenInclude(x => x.Category)
                .Include(x => x.Author)
                .Include(x => x.Author.Biography)
                .ToListAsync();
        }

        [Benchmark]
        public async Task<List<Book>> MultipleIncludeUnChained()
        {
            var query = Context.Books;
            await query.Include(x => x.BookCategories)
                .ThenInclude(x => x.Category).LoadAsync();
            await query.Include(x => x.Author).LoadAsync();
            await query.Include(x => x.Author.Biography).LoadAsync();
            return await query.ToListAsync();
        }
    }
}
