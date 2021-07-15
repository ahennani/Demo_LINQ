using System;
using System.Collections.Generic;

#nullable disable

namespace Demo_LINQ.Models
{
    public partial class Produit
    {
        public string CodeProduit { get; set; }
        public string Libelle { get; set; }
        public string Origine { get; set; }
        public string Couleur { get; set; }

        public override string ToString()
        {
            return $"CodeProduit: {this.CodeProduit}, Libelle: {this.Libelle}, Origine: {this.Origine}, Couleur: {this.Couleur}";
        }
    }
}
