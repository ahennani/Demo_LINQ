using System;
using System.Collections.Generic;

#nullable disable

namespace Demo_LINQ.Models
{
    public partial class Fourniture
    {
        public string NumFourniture { get; set; }
        public string CodeProduit { get; set; }
        public int Quantite { get; set; }

        public virtual Produit CodeProduitNavigation { get; set; }
        public virtual Fournisseur NumFournitureNavigation { get; set; }

        public override string ToString()
        {
            return $"NumFourniture: {this.NumFourniture}, CodeProduit: {this.CodeProduit}, Quantite: {this.Quantite}";
        }
    }
}
