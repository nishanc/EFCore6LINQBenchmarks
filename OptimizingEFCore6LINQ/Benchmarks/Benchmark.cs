using EFCore6LINQBenchmarks.Data;

namespace EFCore6LINQBenchmarks.Benchmarks
{
    public class Benchmark : IDisposable
    {
        protected readonly DataContext Context;
        public Benchmark()
        {
            Context = new DataContext();
        }
        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
