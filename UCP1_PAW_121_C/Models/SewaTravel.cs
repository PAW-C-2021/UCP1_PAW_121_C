using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_121_C.Models
{
    public partial class SewaTravel
    {
        public int IdSewaTravel { get; set; }
        public int? IdJadwal { get; set; }
        public int? IdPelanggan { get; set; }
        public string Biaya { get; set; }
        public string Kuota { get; set; }
        public string TotalBayar { get; set; }

        public virtual Jadwal IdJadwalNavigation { get; set; }
        public virtual Pelanggan IdPelangganNavigation { get; set; }
    }
}
