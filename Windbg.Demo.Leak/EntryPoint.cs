using System;
using System.Threading;

namespace Windbg.Demo
{
    internal class EntryPoint
    {
        public static void Main(string[] args)
        {
            for (int i = 0; i < 50; i++)
            {
                var buffer = new byte[1024 * 1024];
                var x = buffer.ToString();
                var timer = new Timer(_ =>
                {
                    Console.WriteLine(x);
                });

                timer.Change(1000, 1000);
            }

            Thread.Sleep(Timeout.Infinite);
        }
    }
}
