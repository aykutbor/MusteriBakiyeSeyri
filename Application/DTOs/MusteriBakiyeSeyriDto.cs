using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class MusteriBakiyeSeyriDto
    {
        public int MusteriId { get; set; }
        public string MusteriUnvan { get; set; }
        public DateTime EnYuksekBorcTarihi { get; set; }
        public decimal EnYuksekBorcBakiye { get; set; }
        public List<BakiyeDurumuDto> BakiyeSeyri { get; set; } = new List<BakiyeDurumuDto>();
    }

    public class BakiyeDurumuDto
    {
        public DateTime Tarih { get; set; }
        public decimal Bakiye { get; set; }
    }
}
