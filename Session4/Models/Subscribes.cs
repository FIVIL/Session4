using System;
using System.Collections.Generic;

namespace Session4.Models
{
    public partial class Subscribes
    {
        public Guid Id { get; set; }
        public string Comment { get; set; }
        public Guid PatientId { get; set; }
        public Guid SubscriberId { get; set; }
        public DateTime Time { get; set; }
        public Guid RefrencedAppointmentId { get; set; }

        public Patients Patient { get; set; }
        public Doctors Subscriber { get; set; }
    }
}
