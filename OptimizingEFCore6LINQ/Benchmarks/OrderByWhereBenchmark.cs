using BenchmarkDotNet.Attributes;
using OptimizingEFCore6LINQ.Models;

namespace OptimizingEFCore6LINQ.Benchmarks
{
    [MemoryDiagnoser]
    public class OrderByWhereBenchmark : Benchmark
    {
        [Params("500")]
        public string? NameParams { get; set; }
        [Benchmark]
        public List<Book> WhereFirst()
        {
            return Context.Books.Where(x => x.Author.FirstName.Contains(NameParams!))
                .OrderBy(x => x.Title).ToList();
        }

        [Benchmark]
        public List<Book> OrderByFirst()
        {
            return Context.Books.Where(x => x.Author.FirstName.Contains(NameParams!))
                .OrderBy(x => x.Title).ToList();
        }
    }
}
