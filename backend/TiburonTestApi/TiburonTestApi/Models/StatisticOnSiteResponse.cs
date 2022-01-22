using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Storage.Models
{
    public class StatisticOnSiteResponse
    {
        public string UserIP { get; set; }
        public string BannerName { get; set; }
        public string AdvEventsEnum { get; set; }
    }
}
