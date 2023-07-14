using System;
using System.Collections.Generic;

namespace Web_Final.Models.Process;

public partial class T1CreateLot
{
    public int Id { get; set; }

    public string Code { get; set; }

    public int Amount { get; set; }

    public DateTime ActionTime { get; set; }

    public int HisNum { get; set; }

    public string ActionCode { get; set; }

    public string ProcessCode { get; set; }

    public string ItemCode { get; set; }

    public string Constructor { get; set; }

    public DateTime RegDate { get; set; }

    public string? Modifier { get; set; }

    public DateTime? ModDate { get; set; }

    public int? ItemId { get; set; }

    public int? ProcessId { get; set; }

    public virtual T1Item? Item { get; set; }

    public virtual T1Mprocess? Process { get; set; }

    public virtual ICollection<T1LotHi> T1LotHis { get; set; } = new List<T1LotHi>();
}
