using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites
{
    public class MusteriTanim
    {
        public int Id { get; set; }
        public string Unvan {  get; set; }

        public ICollection<MusteriFatura> Faturalar { get; set; }
    }
}
