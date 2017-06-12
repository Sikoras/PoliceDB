using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Police.Models
{
    public class Warrant
    {
        public int ID { get; set; }

        [Display(Name ="Criminal")]
        [Required()]
        public string CriminalName { get; set; }

        [Display(Name = "Crimes Wanted For")]
        [Required()]
        public string Crimes { get; set; }

        [Display(Name = "Officer Filling Warrant")]
        [Required()]
        public string FilingOfficer { get; set; }

        public string Notes { get; set; }
    }

    public class WarrantDBContext : DbContext
    {
        public DbSet<Warrant>Warrants { get; set; }
    }
}