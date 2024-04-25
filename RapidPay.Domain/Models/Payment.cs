using System;
using System.Collections.Generic;

namespace RapidPay.Domain.Models
{
    public partial class Payment
    {
        public int Id { get; set; }
        public decimal? Fee { get; set; }
        public int CardId { get; set; }

        public virtual Card Card { get; set; } = null!;
    }
}
