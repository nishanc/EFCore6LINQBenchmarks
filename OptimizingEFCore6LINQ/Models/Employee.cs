﻿namespace EFCore6LINQBenchmarks.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
