using System;
using System.Collections.Generic;

namespace Web_Final.Models.Data.Account;

public partial class T1Department
{
    public int Id { get; set; }

    public string DepartmentCode { get; set; }

    public virtual ICollection<T1Account> T1Acounts { get; set; } = new List<T1Account>();
}
