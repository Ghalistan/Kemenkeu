using System;
using System.Collections.Generic;

namespace Kemenkeu.Models
{
    public partial class Proyek
    {
        public int Id { get; set; }
        public string NamaProyek { get; set; }
        public int Nilai { get; set; }
        public string Pjpk { get; set; }
        public string Fasilitas { get; set; }
        public string Lokasi { get; set; }
        public string Sektor { get; set; }
        public string Status { get; set; }
        public DateTime TanggalDitambahkan { get; set; }
        public DateTime TanggalDiedit { get; set; }

        public virtual DetailProyek DetailProyek { get; set; }
    }
}
