using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VsProdsWebShop.Infrastructure.Data.Entities;

namespace VsProdsWebShop.Core.Contracts
{
    public interface IReservationService
    {
        List<Reservation> GetUserReservations(string userId);

        List<Reservation> GetReservationsByDate(DateTime date);

        bool IsSlotAvailable(DateTime date, TimeSpan start, int hours);

        Task CreateReservationAsync(
            string userId,
            int serviceId,
            DateTime date,
            TimeSpan startTime,
            int hours);
    }
}
