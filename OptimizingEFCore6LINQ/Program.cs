using BenchmarkDotNet.Running;
using EFCore6LINQBenchmarks.Benchmarks;

namespace EFCore6LINQBenchmarks
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            // BenchmarkRunner.Run<SelectWhereBenchmark>();
            // BenchmarkRunner.Run<OrderByWhereBenchmark>();
            BenchmarkRunner.Run<MultipleIncludeBenchmark>();
        }
    }
}