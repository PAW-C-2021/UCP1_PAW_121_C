using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_121_C.Models
{
    public partial class Mobil
    {
        public Mobil()
        {
            SewaMobils = new HashSet<SewaMobil>();
        }

        public int IdMobil { get; set; }
        public string JenisMobil { get; set; }
        public string NamaMobil { get; set; }
        public string SewaMobil { get; set; }
        public string Status { get; set; }

        public virtual ICollection<SewaMobil> SewaMobils { get; set; }
    }
}
