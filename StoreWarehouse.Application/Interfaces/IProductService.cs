using StoreWarehouse.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreWarehouse.Application.Interfaces
{
    public interface IProductService
    {
        void PublishProduct(Product product);
    }
}
