using System;
using System.Linq;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Running;

namespace Benchmarks
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //var classArr = Enumerable.Range(0, 1000).Select(x => new C { N = x, Str = Guid.NewGuid().ToString() }).ToArray();
            //S[] structArr = classArr.Select(x => new S { N = x.N, Str = x.Str }).ToArray();
            //for (int i = 0; i < 10000; i++)
            //{

            //    structArr.Contains(new S { N = 100, Str = "something" });
            //}
            // BenchmarkRunner.Run<MemoryTraffic>();
            // BenchmarkRunner.Run<TailCallBenchmark>();
            BenchmarkRunner.Run<StructVsClassBenchmark>();
            // BenchmarkRunner.Run<BitCountBenchmark>();
            // BenchmarkRunner.Run<ByteArrayEqualityBenchmark>();
            // BenchmarkRunner.Run<SortedVsUnsourted>();
            // BenchmarkRunner.Run<NewConstraintBenchmark>();
            // BenchmarkRunner.Run<MaxBenchmark>();
        }
        public bool Class(C[] classArr) => classArr.Contains(new C { N = 100, Str = "something" });
        public bool Struct(S[] structArr) => structArr.Contains(new S { N = 100, Str = "something" });
    }
}