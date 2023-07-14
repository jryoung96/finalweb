using System;
using System.Collections.Generic;

namespace Web_Final.Models.Data.WareHouse;

public partial class T1InBound
{
    public long Id { get; set; } // 입고번호 PK

    public string Product { get; set; }  //부품명

    public int Amount { get; set; } // 수량

    public string Vendor { get; set; } //거래처 이름

    public DateTime RegDate { get; set; }// 입고날짜

    public string Contact { get; set; } //담당자 이름

    public int? WareHouseId { get; set; }

    public virtual T1WareHouse? WareHouse { get; set; }
}
