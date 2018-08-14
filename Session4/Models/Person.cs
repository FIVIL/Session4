using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Session4.Models
{
    public class Person
    {
        [Key]
        public Guid ID { get; set; }

        public int PersonalID { get; set; }

        [StringLength(20)]
        public string Name { get; set; }

        [StringLength(20)]
        public string LastName { get; set; }

        public string FullName { get => $"{Name} {LastName}"; }

        [StringLength(40),EmailAddress]
        public string Email { get; set; }

        [StringLength(13),Phone]
        public string Phone { get; set; }

        [StringLength(13),RegularExpression("")]
        public string Mobile { get; set; }
    }
}
