using System;
using System.Collections.Generic;

#nullable disable

namespace Demo_LINQ.Models
{
    public partial class Projet
    {
        public Projet()
        {
            Participers = new HashSet<Participer>();
        }

        public string CodeProjet { get; set; }
        public string NameProjet { get; set; }

        public virtual ICollection<Participer> Participers { get; set; }

        public override string ToString()
        {
            return $"CodeProjet: {this.CodeProjet}, NameProjet: {this.NameProjet}";
        }
    }
}
