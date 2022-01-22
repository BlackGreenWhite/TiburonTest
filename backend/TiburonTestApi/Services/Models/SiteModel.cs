using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Models
{
    public class SiteModel
    {
        public long Id { get; set; }
        public string Url { get; set; }
        public IReadOnlyCollection<BannerModel> Banners { get; set; }
    }
}
