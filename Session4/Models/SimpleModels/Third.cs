using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Session4.Models.SimpleModels
{
    public class Third
    {
        [Key]
        public Guid ID { get; set; }

        public int MyProperty { get; set; }

        public ICollection<Fourth> Fourths { get; set; }
    }
}
