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
    public class SiteService : ISiteService
    {
        private readonly TiburonTestApiContext _tiburonTestApiContext;

        public SiteService(TiburonTestApiContext tiburonTestApiContext)
        {
            _tiburonTestApiContext = tiburonTestApiContext;
        }

        public async Task<SiteModel> Create(Site site)
        {
            _tiburonTestApiContext.Sites.Add(site);
            await _tiburonTestApiContext.SaveChangesAsync();
            return site.ToModel();
        }

        public async Task<SiteModel> Delete(Site site)
        {
            var exister = _tiburonTestApiContext.Sites.FirstOrDefault(x => x.Id == site.Id);
            if (exister != null)
            {
                _tiburonTestApiContext.Sites.Remove(exister);
                await _tiburonTestApiContext.SaveChangesAsync();
                return exister.ToModel();
            }
            return null;
        }

        public async Task<IReadOnlyCollection<SiteModel>> GetAll()
        {
            var sites = await _tiburonTestApiContext.Sites
                .Include(u => u.Banners)
                .Select(x => x.ToModel())
                .ToArrayAsync();
            return sites;
        }

        public async Task<SiteModel> GetById(long id)
        {
            var site = await _tiburonTestApiContext.Sites
                            .FirstOrDefaultAsync(x => x.Id == id);
            return site.ToModel();
        }

        public async Task<SiteModel> Update(Site site)
        {
            var exister = _tiburonTestApiContext.Sites.FirstOrDefault(x => x.Id == site.Id);
            if (exister != null)
            {
                exister.Url = site.Url;
                await _tiburonTestApiContext.SaveChangesAsync();
                return exister.ToModel();
            }
            return null;
        }
        public async Task<SiteModel> GetByUrl(string url)
        {
            var site = await _tiburonTestApiContext.Sites
                            .FirstOrDefaultAsync(x => x.Url == url);
            return site.ToModel();
        }
    }
}
