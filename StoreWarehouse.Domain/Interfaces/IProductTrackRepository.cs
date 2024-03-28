using StoreWarehouse.Domain.Entities;

namespace StoreWarehouse.Domain.Interfaces
{
    public interface IProductTrackRepository
    {
        ProductTrack Add(ProductTrack product);
    }
}
