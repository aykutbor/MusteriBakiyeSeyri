using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public interface IMusteriTanimRepository : IGenericRepository<MusteriTanim>
    {
        Task<IEnumerable<MusteriTanim>> GetAllWithFaturalarAsync();
        Task<MusteriTanim> GetByIdWithFaturalarAsync(int id);
    }
}
