﻿using OptimizingEFCore6LINQ.Data;

namespace OptimizingEFCore6LINQ.Benchmarks
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
