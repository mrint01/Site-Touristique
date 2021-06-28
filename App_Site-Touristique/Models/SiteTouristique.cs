using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace App_Site_Touristique.Models
{
    public class SiteTouristique
    {

        public int Id { get; set; }
        [Required]
        public string nom { get; set; }
        [Required]
        public string Anciete { get; set; }

        public ICollection<Transport> transports { get; set; }
        public ICollection<Activity> activities { get; set; }
        public ICollection<Restaurant> restaurants { get; set; }

    }

}
