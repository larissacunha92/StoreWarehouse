namespace StoreWarehouse.Domain.Entities
{
    public class ProductTrack
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public double Quantity { get; set; }
        public int SourceWarehouseId { get; set; }
        public int TargetWarehouseId { get; set; }
        public string Status { get; set; } = "";
        public DateTime Date { get; set; }
    }
}
