#nullable disable
namespace WebApplication1.Models
{
    public class ManageMedicine
    {
        public int Id { get; set; }
        public string MedicineName { get; set; }
        public string GenericName { get; set; }
        public string MedicineType { get; set; }
        public string Manufacturer { get; set; }
        public string Shelf { get; set; }
        public decimal SellPrice { get; set; }
        public decimal PurchasePrice { get; set; }
        public string Unit { get; set; }
        public int BoxSize { get; set; }
        public string Images { get; set; }
    }
}
