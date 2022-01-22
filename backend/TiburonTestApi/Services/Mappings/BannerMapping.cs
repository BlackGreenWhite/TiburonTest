using Services.Models;
using Storage.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Mappings
{
    public static class BannerMapping
    {
        public static BannerModel ToModel(this Banner banner)
        {
            if (banner == null)
            {
                return null;
            }
            var bannerModel = new BannerModel
            {
                Id = banner.Id,
                BannerName = banner.BannerName,
                BannerUrl = banner.BannerUrl
            };
            return bannerModel;
        }
    }
}
