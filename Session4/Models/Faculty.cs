using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Session4.Models
{
    [Table("f")]
    public class Faculty
    {
        [Key]
        public Guid ID { get; set; }

        [StringLength(20),Required]
        public string Name { get; set; }

        public int Count { get; set; }

        public ICollection<Proffoser> Proffosers { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}
