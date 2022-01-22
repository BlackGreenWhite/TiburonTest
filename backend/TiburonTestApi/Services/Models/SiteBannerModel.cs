using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Models
{
    public class SiteBannerModel
    {
        public long Id { get; set; }
        public long SiteId { get; set; }
        public long BannerId { get; set; }

    }
}
