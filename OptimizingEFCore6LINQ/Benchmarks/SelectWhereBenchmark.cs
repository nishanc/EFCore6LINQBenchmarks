using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;

namespace OptimizingEFCore6LINQ.Benchmarks
{
    [MemoryDiagnoser]
    public class SelectWhereBenchmark : Benchmark
    {
        
        private readonly Consumer _consumer = new Consumer();

        [Benchmark]
        public void WhereFirst()
        {
            Context.Books.Where(x => x.Author.FirstName == "Sample First Name 1").Select(x => x.Author.FirstName)
                .Consume(_consumer);
        }

        [Benchmark]
        public void SelectFirst()
        {
            Context.Books.Select(x => x.Author.FirstName).Where(x => x == "Sample First Name 1")
                .Consume(_consumer);
        }
    }
}
