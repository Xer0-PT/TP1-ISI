namespace TP1.Domain.Models.DTO
{
    public class ProductDTO
    {
        public ProductDTO(string name, double price, int stock, bool active)
        {
            Name = name;
            Price = price;
            Stock = stock;
            Active = active;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public bool Active { get; set; }
    }
}
