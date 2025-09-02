using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class MusteriFaturaDto
    {
        public int Id { get; set; }
        public int MusteriId { get; set; }
        public DateTime FaturaTarihi { get; set; }
        public decimal FaturaTutari {  get; set; }
        public DateTime? OdemeTarihi { get; set; }  
    }
}
