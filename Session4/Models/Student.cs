using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Session4.Models
{
    public enum StudentType
    {
        کارشناسی,
        کارشناسی_ارشد,
        دکتری
    }
    public class Student:Person
    {
        public int StudentNumber { get; set; }

        public double Avg { get; set; }

        public int Passed { get; set; }

        //akhz
        public int Enrolled { get; set; }

        public int FailedCredit { get => Enrolled - Passed; }

        public StudentType Type { get; set; }

        public Guid FacultyID { get; set; }
        public Faculty Faculty { get; set; }
    }
}
