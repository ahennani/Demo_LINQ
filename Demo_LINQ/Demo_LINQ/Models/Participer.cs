using System;
using System.Collections.Generic;

#nullable disable

namespace Demo_LINQ.Models
{
    public partial class Participer
    {
        public string Matricule { get; set; }
        public string CodeProjet { get; set; }

        public virtual Projet CodeProjetNavigation { get; set; }
        public virtual Employe MatriculeNavigation { get; set; }
    }
}
