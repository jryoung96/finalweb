﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_Final.Models.Process
{
	[Table("T1_MProcess")]
	public class MProcess
	{
        public int Id { get; set; } // PK
        public string FacCode { get; set; } // UQ
        public string Code { get; set; } // UQ
        public string Name { get; set; }
        public string? Comment { get; set; } // Null허용

        public string? StockUnit1 { get; set;}
        public string? StockUnit2 { get; set;}

        public string Constructor { get; set; }
        public DateTime RegDate { get; set; }
        public string? Modifier { get; set; }
        public DateTime? ModDate { get; set; }

       
        public Factory? Factories { get; set; }
    }
}
