namespace WealthFy.Domain.Entities
{
    public class Portfolio
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public required string Name { get; set; }
        public required Guid UserId { get; set; }
        public ICollection<Investment> Investments { get; set; } = new List<Investment>();
    }
}
