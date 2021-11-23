using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_121_C.Models
{
    public partial class Driver
    {
        public Driver()
        {
            SewaMobils = new HashSet<SewaMobil>();
        }

        public int IdDriver { get; set; }
        public string NamaDriver { get; set; }
        public string NoHpDriver { get; set; }

        public virtual ICollection<SewaMobil> SewaMobils { get; set; }
    }
}
