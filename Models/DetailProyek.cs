using System;
using System.Collections.Generic;

namespace Kemenkeu.Models
{
    public partial class DetailProyek
    {
        public int Id { get; set; }
        public string DetailProyek1 { get; set; }
        public string Foto { get; set; }

        public virtual Proyek IdNavigation { get; set; }
    }
}
