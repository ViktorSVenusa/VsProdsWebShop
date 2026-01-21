using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VsProdsWebShop.Infrastructure.Data.Entities
{
    public class ReservationSchedule
    {
        public int ReservationId { get; set; }

        [ForeignKey(nameof(ReservationId))]
        public virtual Reservation Reservation { get; set; } = null!;

        public int ScheduleId { get; set; }

        [ForeignKey(nameof(ScheduleId))]
        public virtual Schedule Schedule { get; set; } = null!;
    }
}
