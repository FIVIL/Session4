using System;
using System.Collections.Generic;

namespace Session4.Models
{
    public partial class Universities
    {
        public Universities()
        {
            Certificates = new HashSet<Certificates>();
        }

        public Guid Id { get; set; }
        public string Decryption { get; set; }
        public string Name { get; set; }
        public byte Score { get; set; }

        public ICollection<Certificates> Certificates { get; set; }
    }
}
