using System.ComponentModel.DataAnnotations;

namespace Server2.Models
{
    public class Audtypes
    {
        [Key]
        public int id { get; set; }

        public string? type { get; set; }
        public string? type_eng { get; set; }

        public ICollection<Audience> Audiences { get; set; }
    }
}
