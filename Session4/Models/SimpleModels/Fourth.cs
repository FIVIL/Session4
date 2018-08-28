using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Session4.Models.SimpleModels
{
    public class Fourth
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public DateTime MyProperty { get; set; }

        public Guid? ThirdID { get; set; }
        public Third Third { get; set; }

        public ICollection<Fifth> Fifths { get; set; }
    }
}
