using System.ComponentModel.DataAnnotations;

namespace Server.Models
{
    public class Insts
    {
        [Key]
        public int id { get; set; }

        public string? inst_name { get; set; }

        public string? inst_name_eng { get; set; }

        public ICollection<Audience> Audiences { get; set; }
    }
}
