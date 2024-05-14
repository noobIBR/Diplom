using Server2.Models;
using System.ComponentModel.DataAnnotations;

namespace Server2.Models
{
    public class Deps
    {
        [Key]
        public int id { get; set; }

        public string? dep_name { get; set; }

        public string? dep_name_eng { get; set; }

        public ICollection<Audience> Audiences { get; set; }
    }
}
