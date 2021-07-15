using Demo_LINQ.Models;
using System;
using System.Collections;
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

            //var employes1 = from emp in context.Employes
            //                where emp.NameEmploye.Contains("A")
            //                where emp.NameEmploye.Contains("E")
            //                select emp;

            //var employes2 = context.Employes
            //                     .Where(emp => emp.NameEmploye.Contains("A"))
            //                     .Where(emp => emp.NameEmploye.Contains("E"));

            //var empsCount1 = employes1.Count();
            //var empsCount2 = employes2.Count();



            ///////////////
            /// OfType
            ///////////////

            IList mixed = new ArrayList();
            mixed.Add(12346554);
            mixed.Add("String 1 For Test!!");
            mixed.Add("String 2 For Test!!");
            mixed.Add("String 3 For Test!!");
            mixed.Add("String 4 For Test!!");
            mixed.Add("String 5 For Test!!");
            mixed.Add(new Employe() { Matricule = "Employe-001", Poste = "Poste-001", Salaire = 15000 });
            mixed.Add(new Employe() {Matricule= "Employe-002", Poste="Poste-002", Salaire=12340 });
            mixed.Add(new Projet() { CodeProjet = "Project-001", NameProjet = "Project-001" });
            mixed.Add(new Projet() { CodeProjet = "Project-002", NameProjet = "Project-002" });
            mixed.Add(new Projet() { CodeProjet = "Project-003", NameProjet = "Project-003" });
            mixed.Add(new { Name = "Name-001", Age = "19" });

            var employes = from emp in mixed.OfType<Employe>()
                           select emp;
            var projets = from emp in mixed.OfType<Projet>()
                          select emp;
            var strings = from emp in mixed.OfType<string>()
                          select emp;

            var employes1 = mixed.OfType<Employe>();
            var projets1 = mixed.OfType<Projet>();
            var strings1 = mixed.OfType<string>();

            // TODO: Create Class with Derived
            // When We have Inheritece With EF Core
            // var instcs = context.Set<BaseType>().OfType<Type>();




            Console.ReadKey();
        }
    }
}
