using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WealthFy.Domain.Entities
{
    public class Investment
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public required Guid PortfolioId { get; set; }
        public Portfolio? Portfolio { get; set; }

        public required Guid AssetId { get; set; }
        public Asset? Asset { get; set; }

        public required decimal Amount { get; set; }

        public string? Notes { get; set; }
    }
}
