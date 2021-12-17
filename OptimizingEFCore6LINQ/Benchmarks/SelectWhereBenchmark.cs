using BenchmarkDotNet.Attributes;
using OptimizingEFCore6LINQ.Models;

namespace OptimizingEFCore6LINQ.Benchmarks
{
    [MemoryDiagnoser]
    public class SelectWhereBenchmark : Benchmark
    {
        [Params("1", "500")]
        public string? NameParams { get; set; }

        [Benchmark]
        public List<string> WhereFirst()
        {
            return Context.Employees
                .Where(x => x.Name.Contains(NameParams!))
                .Select(x => x.Name).ToList();
        }

        [Benchmark]
        public List<string> SelectFirst()
        {
            return Context.Employees
                .Select(x => x.Name)
                .Where(x => x.Contains(NameParams!)).ToList();
        }

        [Benchmark]
        public List<Company> WhereFirstWithJoin()
        {
            return Context.Employees
                .Where(x => x.Name.Contains(NameParams!))
                .Select(x => x.Company).ToList();
        }

        [Benchmark]
        public List<Company> SelectFirstWithJoin()
        {
            return Context.Employees
                .Select(x => x.Company)
                .Where(x => x.Employees.Any(y => y.Name.Contains(NameParams!))).ToList();
        }
    }
}
