using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IMusteriService
    {
        Task<IEnumerable<MusteriTanimDto>> GetAllMusterilerAsync();
        Task<MusteriBakiyeSeyriDto> GetMusteriBakiyeSeyriAsync(int musteriId);
    }
}
