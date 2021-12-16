using BenchmarkDotNet.Running;
using OptimizingEFCore6LINQ.Benchmarks;

namespace OptimizingEFCore6LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<SelectWhereBenchmark>();
        }
    }
}