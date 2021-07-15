using System;
using System.Collections.Generic;

#nullable disable

namespace Demo_LINQ.Models
{
    public partial class Department
    {
        public Department()
        {
            Employes = new HashSet<Employe>();
        }

        public string NumDepartment { get; set; }
        public string NameDepartment { get; set; }
        public string Lieu { get; set; }

        public virtual ICollection<Employe> Employes { get; set; }

        public override string ToString()
        {
            return $"NumDepartment: {this.NumDepartment}, NameDepartment: {this.NameDepartment}, Lieu: {this.Lieu}";
        }
    }
}
