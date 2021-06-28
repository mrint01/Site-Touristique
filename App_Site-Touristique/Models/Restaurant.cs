using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace App_Site_Touristique.Models
{
    public class Restaurant
    {
        public int Id  { get; set; }
        [Required]

        public string Nom { get; set; }
        [Required]
        public string NumTel { get; set; }
        [Required]
        public string leType { get; set; }

    }
}