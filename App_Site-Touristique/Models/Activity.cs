using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace App_Site_Touristique.Models
{
    public class Activity
    {
        public int Id { get; set; }
        [Required]
        public string Nom { get; set; }

        [Required]
        public string Genre { get; set; }
        [Required]
        public float prix { get; set; }
        public SiteTouristique siteTouristiques { get; set; }
    }
}