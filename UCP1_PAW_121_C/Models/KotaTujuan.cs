using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_121_C.Models
{
    public partial class KotaTujuan
    {
        public KotaTujuan()
        {
            Jadwals = new HashSet<Jadwal>();
        }

        public int IdKotaTujuan { get; set; }
        public string KotaTujuan1 { get; set; }
        public string Biaya { get; set; }

        public virtual ICollection<Jadwal> Jadwals { get; set; }
    }
}
