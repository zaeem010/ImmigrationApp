using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ImmigrationApp.Models
{
    public class States
    {
        [Key]
        public long Id { get; set; }
        [MaxLength(455)]
        public string region { get; set; }
        [MaxLength(455)]
        public string countrycode { get; set; }
    }
    public class Cities
    {
        [Key]
        public long Id { get; set; }
        [MaxLength(455)]
        public string cityregion { get; set; }
        [MaxLength(455)]
        public string city { get; set; }
        [MaxLength(455)]
        public string region { get; set; }
        [MaxLength(455)]
        public string countrycode { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
    }
}
