using System.Runtime.CompilerServices;
using BenchmarkDotNet.Attributes;
using Microsoft.EntityFrameworkCore;
using OptimizingEFCore6LINQ.Models;

namespace OptimizingEFCore6LINQ.Benchmarks
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
            var x = await query.ToListAsync();
            return x;
        }
    }
}
