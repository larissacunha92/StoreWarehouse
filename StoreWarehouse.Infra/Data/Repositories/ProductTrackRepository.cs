using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreWarehouse.Domain.Entities;
using StoreWarehouse.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace StoreWarehouse.Infra.Data.Repositories
{
    public class ProductTrackRepository: IProductTrackRepository
    {
        protected readonly DataContext _context;
        public ProductTrackRepository(DataContext context)
        {
            _context = context;
        }

        public ProductTrack Add(ProductTrack product)
        {
            _context.ProductTrack.Add(product);
            _context.SaveChangesAsync();

            return product;
        }
    }
}
