using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Session4.Models
{
    public enum MratabelEmli
    {
        مربی,
        استادیار,
        دانشیار,
        استاد_تمام
    }
    public class Proffoser : Person
    {
        public int ShomarePersoneli { get; set; }

        [DataType(DataType.Date)]
        public DateTime SaleVorudBeDaneshgah { get; set; }

        public MratabelEmli MratabelEmli { get; set; }

        public ICollection<ProffessorFaculty> ProffessorFaculties { get; set; }

    }
}
