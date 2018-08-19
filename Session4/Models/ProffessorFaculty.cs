using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Session4.Models
{
    public class ProffessorFaculty
    {
        public Guid ProffoserID { get; set; }
        public Proffoser Proffoser { get; set; }

        public Guid FacultyID { get; set; }
        public Faculty Faculty { get; set; }
    }
}
