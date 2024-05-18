using Server2.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server2.Models
{
    public class Audience
    {
        [Key]
        public int ID { get; set; }

        public string? aud_name { get; set; }

        [ForeignKey("Audtypes")]
        public int audtype_id { get; set; }
        public Audtypes? audtype_ { get; set; }

        public int campus { get; set; }
        public int floor { get; set; }
        public string? aud_num { get; set; }
        public string? workplaces_num { get; set; }
        public string? equipment { get; set; }

        [ForeignKey("Insts")]
        public int? inst_id { get; set; }
        public Insts? inst_ { get; set; }

        [ForeignKey("Deps")]
        public int? dep_id { get; set; }
        public Deps? dep_ { get; set; }

        public string? equipment_eng { get; set; }
    }
}
