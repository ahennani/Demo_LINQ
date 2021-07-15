using System;
using System.Collections.Generic;

#nullable disable

namespace Demo_LINQ.Models
{
    public partial class Employe
    {
        public Employe()
        {
            InverseIdSupNavigation = new HashSet<Employe>();
            Participers = new HashSet<Participer>();
        }

        public string Matricule { get; set; }
        public string NameEmploye { get; set; }
        public string Poste { get; set; }
        public string IdSup { get; set; }
        public decimal Salaire { get; set; }
        public string NumDepartment { get; set; }

        public virtual Employe IdSupNavigation { get; set; }
        public virtual Department NumDepartmentNavigation { get; set; }
        public virtual ICollection<Employe> InverseIdSupNavigation { get; set; }
        public virtual ICollection<Participer> Participers { get; set; }

        public override string ToString()
        {
            return $"Matricule: {this.Matricule}, NameEmploye: {this.NameEmploye}, Poste: {this.Poste}, " +
                   $"IdSup: {this.IdSup}, NumDepartment: {this.NumDepartment}";
        }
    }
}
