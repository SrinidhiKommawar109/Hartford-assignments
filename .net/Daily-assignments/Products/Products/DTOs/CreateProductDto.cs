namespace Products.DTOs
{
    public class CreateProductDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public string Category {  get; set; }
    }
}
