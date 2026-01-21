using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VsProdsWebShop.Infrastructure.Data.Entities
{
    public class Reservation
    {


        [Key]
        public int Id { get; set; }

        // Кой потребител е направил резервацията
        [Required]
        public string UserId { get; set; } = null!;

        [ForeignKey(nameof(UserId))]
        public virtual ApplicationUser User { get; set; } = null!;

        // Коя услуга е резервирана
        [Required]
        public int ServiceAvailableId { get; set; }

        [ForeignKey(nameof(ServiceAvailableId))]
        public virtual ServiceAvailable ServiceAvailable { get; set; } = null!;

        // Кой час от графика е избран (начален слот)
        [Required]
        public int ScheduleId { get; set; }

        [ForeignKey(nameof(ScheduleId))]
        public virtual Schedule Schedule { get; set; } = null!;

        // Дата и час на резервацията/поръчката
        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Цена на услугата в момента на резервацията
        [Column(TypeName = "decimal(18,2)")]
        public decimal PriceAtBooking { get; set; }

        public bool IsPaid { get; set; }

        [Required]
        [Range(1, 8)]
        public int Hours { get; set; }

        public virtual ICollection<ReservationSchedule> ReservationSchedules { get; set; } = new List<ReservationSchedule>();

    }
}