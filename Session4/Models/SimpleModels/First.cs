using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Session4.Models.SimpleModels
{
    public class First
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public double MyProperty { get; set; }

        public int? SeccondID { get; set; }
        public Seccond Seccond { get; set; }

        public ICollection<Fifth> Fifths { get; set; }
    }
}
