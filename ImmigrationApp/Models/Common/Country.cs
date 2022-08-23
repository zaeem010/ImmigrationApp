using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ImmigrationApp.Models
{
    public class Country
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(155)]
        public string CountryName { get; set; }
        [MaxLength(55)]
        public string CountryCode { get; set; }
    }
}
