using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VsProdsWebShop.Core.Contracts
{
    public interface IScheduleService
    {
        List<TimeSpan> GetDailySlots(); 
    }
}
