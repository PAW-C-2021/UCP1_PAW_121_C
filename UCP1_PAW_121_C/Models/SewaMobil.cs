using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_121_C.Models
{
    public partial class SewaMobil
    {
        public int IdSewaMobil { get; set; }
        public int? IdDriver { get; set; }
        public int? IdMobil { get; set; }
        public int? IdPelanggan { get; set; }
        public string JumlahHari { get; set; }
        public string Total { get; set; }

        public virtual Driver IdDriverNavigation { get; set; }
        public virtual Mobil IdMobilNavigation { get; set; }
        public virtual Pelanggan IdPelangganNavigation { get; set; }
    }
}
