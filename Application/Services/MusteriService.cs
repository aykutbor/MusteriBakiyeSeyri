using Application.DTOs;
using AutoMapper;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class MusteriService : IMusteriService
    {
        private readonly IMusteriTanimRepository _musteriTanimRepository;
        private readonly IMapper _mapper;

        public MusteriService(IMusteriTanimRepository musteriTanimRepository, IMapper mapper)
        {
            _musteriTanimRepository = musteriTanimRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MusteriTanimDto>> GetAllMusterilerAsync()
        {
            var musteriler = await _musteriTanimRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<MusteriTanimDto>>(musteriler);
        }

        public async Task<MusteriBakiyeSeyriDto> GetMusteriBakiyeSeyriAsync(int musteriId)
        {
            var musteri = await _musteriTanimRepository.GetByIdWithFaturalarAsync(musteriId);

            if (musteri == null)
            {
                return null;
            }

            // Tüm fatura ve ödeme tarihlerini toplayın
            var tumTarihler = musteri.Faturalar
                                    .Select(f => f.FaturaTarihi.Date)
                                    .Concat(musteri.Faturalar.Where(f => f.OdemeTarihi.HasValue).Select(f => f.OdemeTarihi.Value.Date))
                                    .Distinct()
                                    .OrderBy(d => d)
                                    .ToList();

            decimal currentBakiye = 0;
            decimal enYuksekBorcBakiye = 0;
            DateTime enYuksekBorcTarihi = DateTime.MinValue;

            var bakiyeSeyriList = new List<BakiyeDurumuDto>();

            foreach (var tarih in tumTarihler)
            {
                // Bu tarihe kadar kesilen faturaları ekle
                currentBakiye += musteri.Faturalar
                                        .Where(f => f.FaturaTarihi.Date == tarih)
                                        .Sum(f => f.FaturaTutari);

                // Bu tarihte yapılan ödemeleri düş
                currentBakiye -= musteri.Faturalar
                                        .Where(f => f.OdemeTarihi.HasValue && f.OdemeTarihi.Value.Date == tarih)
                                        .Sum(f => f.FaturaTutari);

                bakiyeSeyriList.Add(new BakiyeDurumuDto { Tarih = tarih, Bakiye = currentBakiye });

                if (currentBakiye > enYuksekBorcBakiye)
                {
                    enYuksekBorcBakiye = currentBakiye;
                    enYuksekBorcTarihi = tarih;
                }
            }

            return new MusteriBakiyeSeyriDto
            {
                MusteriId = musteri.Id,
                MusteriUnvan = musteri.Unvan,
                EnYuksekBorcBakiye = enYuksekBorcBakiye,
                EnYuksekBorcTarihi = enYuksekBorcTarihi,
                BakiyeSeyri = bakiyeSeyriList
            };
        }
    }
}
