using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VsProdsWebShop.Infrastructure.Data.Entities
{
    public class ServiceAvailable
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string ServiceName { get; set; } = null!;

        [Required]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; } = null!;

        [MaxLength(300)]
        public string ServiceDescription { get; set; } = null!;

        [Required]
        public int ServiceDurationInMinutes { get; set; }

        public string Picture { get; set; } = null!;

        public decimal Price { get; set; }

       
       
    }
}
