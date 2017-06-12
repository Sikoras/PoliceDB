using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Police.Models
{
    public class Criminal
    {
        public int ID { get; set; }


        [Display(Name="Criminal")]
        [Required()]
        public string CriminalName { get; set; }

        [Display(Name = "Date of Arrest")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required()]
        public DateTime DateOfArrest { get; set; }

        [Required()]
        public string Crimes { get; set; }

        [Required()]
        public string Sanction { get; set; }

        [Display(Name ="Arresting Officer")]
        [Required()]
        public string ArrestingOfficer { get; set; }
    }

    public class CriminalDBContext : DbContext
    {
        public DbSet<Criminal>Criminals { get; set; }
    }
}