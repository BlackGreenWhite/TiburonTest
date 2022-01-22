using Services.Models;
using Storage.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Mappings
{
    public static class SiteBannerMapping
    {
        public static SiteBannerModel ToModel(this SiteBanner siteBanner)
        {
            if (siteBanner == null)
            {
                return null;
            }
            var siteBannerModel = new SiteBannerModel
            {
                Id = siteBanner.Id,
                BannerId = siteBanner.BannerId,
                SiteId = siteBanner.SiteId
            };
            return siteBannerModel;
        }
    }
}
