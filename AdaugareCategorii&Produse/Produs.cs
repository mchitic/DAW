using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplicationProiect.Models
{
    public class Produs
    {   [Key]
        public int ProductId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [DisplayName("Upload Image")]
       // public String  ImagePath { get; set; }
        public byte[] ImageFile { get; set; }
        public int Rating { get; set; }
    }

    public class    ProdusDBContext : DbContext
    {
        public ProdusDBContext() : base("DefaultConnection") { }
        public DbSet<Produs> Produse { get; set; }
    }
}