using Storage;
using Storage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiburonTestApi.Models
{
    public class StatisticRequest
    {
        public string SiteUrl { get; set; }
        public string UserIP{ get; set; }
        public string BannerName { get; set; }
        public AdvEventsEnum AdvEventsEnum;
    }
}
