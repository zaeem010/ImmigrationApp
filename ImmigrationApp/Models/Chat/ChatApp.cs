using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ImmigrationApp.Models
{
    public class ChatAppHub
    {
        [Key]
        public long Id { get; set; }
        public long PeopleHubId { get; set; }
        public int UserId { get; set; }
        [MaxLength(55)]
        public string Type { get; set; }
        [MaxLength(1000)]
        public string Message { get; set; }
        public DateTime MessageDateTime { get; set; }
        public bool seen { get; set; }
        public virtual User User { get; set; }
    }
    public class PeopleHub
    {
        [Key]
        public long Id { get; set; }
        public int UserId { get; set; }
        public int ConnectedId { get; set; }
        public virtual User User { get; set; }
        public virtual List<ChatAppHub> ChatAppHubList { get; set; }
        public PeopleHub()
        {
            ChatAppHubList = new List<ChatAppHub>();
        }
    }
}
