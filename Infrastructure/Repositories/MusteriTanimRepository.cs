using Domain.Entites;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;


namespace MusteriBakiyeSeyri.Infrastructure.Repositories
{
    public class MusteriTanimRepository : GenericRepository<MusteriTanim>, IMusteriTanimRepository
    {
        public MusteriTanimRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<MusteriTanim>> GetAllWithFaturalarAsync()
        {
            return await _dbSet.Include(m => m.Faturalar).ToListAsync();
        }

        public async Task<MusteriTanim> GetByIdWithFaturalarAsync(int id)
        {
            return await _dbSet.Include(m => m.Faturalar).FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}