using System;
using System.Collections.Generic;
using Web_Final.Models.Data.Process;

namespace Web_Final.Models.Data.WareHouse;

public partial class T1OutBound
{
    public long Id { get; set; } //PK

    public string Product { get; set; }  //부품명

    public int Amount { get; set; } // 수량

    public string Contact { get; set; } //담당자

    public DateTime RegDate { get; set; } //출고날짜

    public int? WareHouseId { get; set; }

    public int? MprocessId { get; set; }

    public virtual T1Mprocess? Mprocess { get; set; }

    public virtual T1WareHouse? WareHouse { get; set; }
}
