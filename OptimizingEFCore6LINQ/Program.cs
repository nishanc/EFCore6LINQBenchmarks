using BenchmarkDotNet.Running;
using OptimizingEFCore6LINQ.Benchmarks;

namespace OptimizingEFCore6LINQ
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            // BenchmarkRunner.Run<SelectWhereBenchmark>();
            BenchmarkRunner.Run<OrderByWhereBenchmark>();
        }
    }
}