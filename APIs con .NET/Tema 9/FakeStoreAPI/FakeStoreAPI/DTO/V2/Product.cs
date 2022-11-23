namespace FakeStoreAPI.DTO.V2
{
    public class Product
    {
        public Guid InternalId { get; set; } = Guid.NewGuid();
        public int Id { get; set; }
        public String Title { get; set; } = String.Empty;
        public float Price { get; set; }
        public string Description { get; set; } = String.Empty;
        public string Category { get; set; } = String.Empty;
        public string Image { get; set; } = String.Empty;
    }
}
