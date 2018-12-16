using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AdaugareProduse.Models
{
    public class Produs
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Titlu { get; set; }
        [Required]
        public string Descriere { get; set; }
        [Required]
        public float Pret { get; set; }
        public int Rating { get; set; }
        public string Review { get; set; }
        public int IdCategorie { get; set; }

        public virtual Categorie Categorie { get; set; }
    }

    public class ProdusDBContext : DbContext
    {
        public ProdusDBContext() : base("DBConnectionString2") { }
        public DbSet<Produs> Produse { get; set; }
        public DbSet<Categorie> Categorii { get; set; }
    }
}