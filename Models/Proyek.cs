using System;
using System.Collections.Generic;

namespace Kemenkeu.Models
{
    public partial class Proyek
    {
        public int Id { get; set; }
        public string NamaProyek { get; set; }
        public int NilaiProyek { get; set; }
        public string Sektor { get; set; }
        public string DetailProyek { get; set; }
        public string Provinsi { get; set; }
        public string Kota { get; set; }
        public string StatusProyek { get; set; }
    }
}
