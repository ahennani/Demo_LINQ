using Demo_LINQ.Models;
using System;
using System.Linq;

namespace Demo_LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new AppDbContext();

            ///////////////
            /// Where
            ///////////////

            var employes1 = from emp in context.Employes
                            where emp.NameEmploye.Contains("A")
                            where emp.NameEmploye.Contains("E")
                            select emp;

            var employes2 = context.Employes
                                 .Where(emp => emp.NameEmploye.Contains("A"))
                                 .Where(emp => emp.NameEmploye.Contains("E"));

            var empsCount1 = employes1.Count();
            var empsCount2 = employes2.Count();








            Console.ReadKey();
        }
    }
}
