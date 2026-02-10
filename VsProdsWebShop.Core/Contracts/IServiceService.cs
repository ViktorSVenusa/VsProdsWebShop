using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VsProdsWebShop.Infrastructure.Data.Entities;

namespace VsProdsWebShop.Core.Contracts
{
    public interface IServiceService
    {
        List<ServiceAvailable> GetAll();

        List<ServiceAvailable> GetByCategory(int categoryId);

        ServiceAvailable GetById(int id);
    }
}
