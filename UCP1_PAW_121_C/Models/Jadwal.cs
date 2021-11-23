using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_121_C.Models
{
    public partial class Jadwal
    {
        public Jadwal()
        {
            SewaTravels = new HashSet<SewaTravel>();
        }

        public int IdJadwal { get; set; }
        public int? IdKotaTujuan { get; set; }
        public string Jam { get; set; }
        public DateTime? TglSewa { get; set; }
        public string Tujuan { get; set; }

        public virtual KotaTujuan IdKotaTujuanNavigation { get; set; }
        public virtual ICollection<SewaTravel> SewaTravels { get; set; }
    }
}
