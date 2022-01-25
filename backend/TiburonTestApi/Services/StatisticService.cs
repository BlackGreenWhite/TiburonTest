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
    public class StatisticService : IStatisticService
    {
        private readonly TiburonTestApiContext _tiburonTestApiContext;

        public StatisticService(TiburonTestApiContext tiburonTestApiContext)
        {
            _tiburonTestApiContext = tiburonTestApiContext;
        }

        public async Task<StatisticModel> Create(Statistic statistic)
        {
            _tiburonTestApiContext.Statistics.Add(statistic);
            await _tiburonTestApiContext.SaveChangesAsync();
            return statistic.ToModel();
        }

        public async Task<StatisticModel> Delete(Statistic statistic)
        {
            var exister = _tiburonTestApiContext.Statistics.FirstOrDefault(x => x.Id == statistic.Id);
            if (exister != null)
            {
                _tiburonTestApiContext.Statistics?.Remove(exister);
                await _tiburonTestApiContext.SaveChangesAsync();
                return exister.ToModel();
            }
            return null;
        }

        public async Task<IReadOnlyCollection<StatisticModel>> GetAll()
        {
            var statistics = await _tiburonTestApiContext.Statistics
                .Select(x => x.ToModel())
                .ToArrayAsync();
            return statistics;
        }
        public async Task<IReadOnlyCollection<StatisticModel>> GetAllOnSite(long siteId)
        {
            var statistics = await _tiburonTestApiContext.Statistics
                .Where(x=>x.SiteBanner.SiteId == siteId)
                .Select(x => x.ToModel())
                .ToArrayAsync();
            return statistics;
        }

        public async Task<StatisticModel> GetById(long id)
        {
            var statistic = await _tiburonTestApiContext.Statistics
                            .FirstOrDefaultAsync(x => x.Id == id);
            return statistic.ToModel();
        }

        public async Task<StatisticModel> Update(Statistic statistic)
        {
            var exister = _tiburonTestApiContext.Statistics.FirstOrDefault(x => x.Id == statistic.Id);
            if (exister != null)
            {
                exister.SiteBannerId = statistic.SiteBannerId;
                exister.UserId = statistic.UserId;
                exister.AdvEvent = statistic.AdvEvent;
                await _tiburonTestApiContext.SaveChangesAsync();
                return exister.ToModel();
            }
            return null;
        }

        public async Task<StatisticModel> GetByUserAndSiteBanner(long userId, long siteBannerId)
        {
            var statistic = await _tiburonTestApiContext.Statistics
                            .FirstOrDefaultAsync(x => x.UserId == userId && x.SiteBannerId == siteBannerId);
            return statistic.ToModel();
        }

    }
}
