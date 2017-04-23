using System;
using System.IO;
using System.Linq;

namespace ConsoleApplication2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var allBytes = File.ReadAllBytes(@"C:\Users\Andrew\RiderProjects\MAC\MAC\bin\Release\MAC.exe");
            var meta = PeMetaViewer.GetPeMeta(allBytes);
            Console.WriteLine(meta);
        }
    }
}