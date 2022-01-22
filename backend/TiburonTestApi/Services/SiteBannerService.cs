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
    public class SiteBannerService : ISiteBannerService
    {
        private readonly TiburonTestApiContext _tiburonTestApiContext;

        public SiteBannerService(TiburonTestApiContext tiburonTestApiContext)
        {
            _tiburonTestApiContext = tiburonTestApiContext;
        }

        public async Task<SiteBannerModel> Create(SiteBanner siteBanner)
        {
            _tiburonTestApiContext.SiteBanners?.Add(siteBanner);
            await _tiburonTestApiContext.SaveChangesAsync();
            return siteBanner.ToModel();
        }

        public async Task<SiteBannerModel> Delete(SiteBanner siteBanner)
        {
            var exister = _tiburonTestApiContext.SiteBanners?.FirstOrDefault(x => x.Id == siteBanner.Id);
            if (exister != null)
            {
                _tiburonTestApiContext.SiteBanners?.Remove(exister);
                await _tiburonTestApiContext.SaveChangesAsync();
                return exister.ToModel();
            }
            return null;
        }

        public async Task<IReadOnlyCollection<SiteBannerModel>> GetAll()
        {
            var siteBanners = await _tiburonTestApiContext.SiteBanners?
                .Select(x => x.ToModel())
                .ToListAsync();
            return siteBanners;
        }

        public async Task<SiteBannerModel> GetById(long id)
        {
            var siteBanner = await _tiburonTestApiContext.SiteBanners?
                            .FirstOrDefaultAsync(x => x.Id == id);
            return siteBanner.ToModel();
        }

        public async Task<SiteBannerModel> Update(SiteBanner siteBanner)
        {
            var exister = _tiburonTestApiContext.SiteBanners?.FirstOrDefault(x => x.Id == siteBanner.Id);
            if (exister != null)
            {
                exister.SiteId = siteBanner.SiteId;
                exister.BannerId = siteBanner.BannerId;
                await _tiburonTestApiContext.SaveChangesAsync();
                return exister.ToModel();
            }
            return null;
        }
        public async Task<SiteBannerModel> GetBySiteAndBanner(long bannerId, long siteId)
        {
            var siteBanner = await _tiburonTestApiContext.SiteBanners?
                            .FirstOrDefaultAsync(x => x.BannerId == bannerId && x.SiteId == siteId);
            return siteBanner.ToModel();
        }
    }
}
