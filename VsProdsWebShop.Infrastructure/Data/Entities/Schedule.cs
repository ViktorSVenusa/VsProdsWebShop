using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VsProdsWebShop.Infrastructure.Data.Entities
{
    public class Schedule
    {

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public bool IsAvailable { get; set; }


        public virtual ICollection<ReservationSchedule> ReservationSchedules { get; set; } = new List<ReservationSchedule>();



    }
}
