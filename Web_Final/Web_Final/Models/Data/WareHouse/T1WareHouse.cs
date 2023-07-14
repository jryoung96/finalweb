using System;
using System.Collections.Generic;

namespace Web_Final.Models.Data.WareHouse;

public partial class T1WareHouse
{
    public int Id { get; set; }

    public string Product { get; set; }

    public string Item { get; set; }

    public int Amount { get; set; }

    public virtual ICollection<T1InBound> T1InBounds { get; set; } = new List<T1InBound>();

    public virtual ICollection<T1OutBound> T1OutBounds { get; set; } = new List<T1OutBound>();
}
