using Microsoft.AspNetCore.Mvc;
using Services.Models;
using Storage.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IStatisticService: ICRUD<Statistic, StatisticModel>
    {
        Task<StatisticModel> GetByUserAndSiteBanner(long userId, long siteBannerId);
        Task<IReadOnlyCollection<StatisticModel>> GetAllOnSite(long siteId);
    }
}
