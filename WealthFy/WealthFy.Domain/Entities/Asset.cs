namespace WealthFy.Domain.Entities
{
    public class Asset
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public required string Symbol { get; set; }
        public required string Name { get; set; }
        public required string Type { get; set; }
        public string? LogoUrl { get; set; }
    }
}
