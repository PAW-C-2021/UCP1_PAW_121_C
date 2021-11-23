using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_121_C.Models
{
    public partial class Pelanggan
    {
        public Pelanggan()
        {
            SewaMobils = new HashSet<SewaMobil>();
            SewaTravels = new HashSet<SewaTravel>();
        }

        public int IdPelanggan { get; set; }
        public string NamaPelanggan { get; set; }
        public string NoHpPelanggan { get; set; }
        public string Alamat { get; set; }

        public virtual ICollection<SewaMobil> SewaMobils { get; set; }
        public virtual ICollection<SewaTravel> SewaTravels { get; set; }
    }
}
