using System;
using System.Collections.Generic;

namespace Web_Final.Models.Data.Account;

public partial class T1Account
{
    public int Id { get; set; }

    public string UserId { get; set; }

    public string Name { get; set; }

    public string DepartmentCode { get; set; }

    public string Position { get; set; }

    public int Authority { get; set; } = 1; //관리권한

    public string PassWord { get; set; }

    public DateTime RegDate { get; set; }

    public int? DepartmentId { get; set; }

    public virtual T1Department? Department { get; set; }
}
