using System;
using System.Collections.Generic;

namespace Kemenkeu.Models
{
    public partial class Berita
    {
        public int Id { get; set; }
        public string JudulBerita { get; set; }
        public string DetailBerita { get; set; }
        public string Foto { get; set; }
        public DateTime TanggalDitambahkan { get; set; }
        public DateTime TanggalDiedit { get; set; }
    }
}
