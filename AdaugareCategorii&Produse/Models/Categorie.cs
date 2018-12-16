using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdaugareProduse.Models
{
    public class Categorie
    {
        [Key]
        public int IdCategorie { get; set; }
        [Required]
        public string NumeCategorie { get; set; }

        public virtual ICollection<Produs> Produs { get; set; }
    }
}