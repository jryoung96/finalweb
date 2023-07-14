using System;
using System.Collections.Generic;

namespace Web_Final.Models.Process;

public partial class T1Item
{
    public int Id { get; set; }

    public string Code { get; set; }

    public string Name { get; set; }

    public string Type { get; set; }
    public string Constructor { get; set; }

    public DateTime RegDate { get; set; }

    public string? Modifier { get; set; }

    public DateTime? ModDate { get; set; }

    public virtual ICollection<T1CreateLot> T1CreateLots { get; set; } = new List<T1CreateLot>();
}
