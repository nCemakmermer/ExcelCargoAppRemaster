using ExcelCargoAppRemaster.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExcelCargoApp.Data
{
    public class Rapor
    {
        public int SIRA_NO { get; set; }
        public int ADET { get; set; }
        public int KG_DESİ { get; set; }
        public string MESAFE { get; set; }
        public double UCRET { get; set; }
    }
}
