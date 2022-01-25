using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;
using Services.Mappings;
using Services.Models;
using Storage;
using Storage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BannerService : IBannerService
    {
        private readonly TiburonTestApiContext _tiburonTestApiContext;

        public BannerService(TiburonTestApiContext tiburonTestApiContext)
        {
            _tiburonTestApiContext = tiburonTestApiContext;
        }

        public async Task<BannerModel> Create(Banner banner)
        {
            _tiburonTestApiContext.Banners.Add(banner);
            await _tiburonTestApiContext.SaveChangesAsync();
            return banner.ToModel();
        }

        public async Task<BannerModel> Delete(Banner banner)
        {
            var exister = _tiburonTestApiContext.Banners.FirstOrDefault(x => x.Id == banner.Id);
            if (exister != null)
            {
                _tiburonTestApiContext.Banners.Remove(exister);
                await _tiburonTestApiContext.SaveChangesAsync();
                return exister.ToModel();
            }
            return null;
        }

        public async Task<IReadOnlyCollection<BannerModel>> GetAll()
        {
            var banners = await _tiburonTestApiContext.Banners
                .Select(x => x.ToModel())
                .ToArrayAsync();
            return banners;
        }

        public async Task<BannerModel> GetById(long id)
        {
            var banner = await _tiburonTestApiContext.Banners
                            .FirstOrDefaultAsync(x => x.Id == id);
            return banner.ToModel();
        }

        public async Task<BannerModel> Update(Banner banner)
        {
            var exister = _tiburonTestApiContext.Banners.FirstOrDefault(x => x.Id == banner.Id);
            if (exister != null)
            {
                exister.BannerName = banner.BannerName;
                await _tiburonTestApiContext.SaveChangesAsync();
                return exister.ToModel();
            }
            return null;
        }

        public async Task<BannerModel> GetByName(string name)
        {
            var banner = await _tiburonTestApiContext.Banners
                            .FirstOrDefaultAsync(x => x.BannerName == name);
            return banner.ToModel();
        }
    }
}
