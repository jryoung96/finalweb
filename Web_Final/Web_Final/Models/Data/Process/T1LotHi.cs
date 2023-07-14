using System;
using System.Collections.Generic;

namespace Web_Final.Models.Data.Process;

public partial class T1LotHi
{
    public int Id { get; set; }

    public DateTime? ModDate { get; set; }

    public string? Modifier { get; set; }

    public int? CreateLotId { get; set; }

    public virtual T1CreateLot? CreateLot { get; set; }
}
