using System;
using System.Collections.Generic;
using Web_Final.Models.Data.WareHouse;

namespace Web_Final.Models.Data.Process;

public partial class T1Mprocess
{
    public int Id { get; set; }

    public string Code { get; set; }

    public string Name { get; set; }

    public string? Coment { get; set; }

    public string EquipCode { get; set; }

    public string? StockUnit1 { get; set; }

    public string? StockUnit2 { get; set; }

    public string Constructor { get; set; }

    public DateTime RegDate { get; set; }

    public string? Modifier { get; set; }

    public DateTime? ModDate { get; set; }

    public int? EquipmentId { get; set; }

    public int? FactoriesId { get; set; }

    public virtual T1Equipment? Equipment { get; set; }

    public virtual T1Factory? Factories { get; set; }

    public virtual ICollection<T1CreateLot> T1CreateLots { get; set; } = new List<T1CreateLot>();

    public virtual ICollection<T1OutBound> T1OutBounds { get; set; } = new List<T1OutBound>();
}
