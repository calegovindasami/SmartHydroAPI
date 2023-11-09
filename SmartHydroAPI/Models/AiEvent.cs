using System;
using System.Collections.Generic;

namespace SmartHydroAPI.Models
{
    public partial class AiEvent
    {
        public int EventId { get; set; }
        public string Description { get; set; } = null!;
        public DateTime Timestamp { get; set; }
    }
}
