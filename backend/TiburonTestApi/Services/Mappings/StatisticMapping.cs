using Services.Models;
using Storage.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Mappings
{
    public static class StatisticMapping
    {
        public static StatisticModel ToModel(this Statistic statistic)
        {
            if (statistic == null)
            {
                return null;
            }
            var statisticModel = new StatisticModel
            {
                Id = statistic.Id,
                SiteBannerId = statistic.SiteBannerId,
                UserId = statistic.UserId,
                AdvEvent = statistic.AdvEvent
            };
            return statisticModel;
        }
    }
}
