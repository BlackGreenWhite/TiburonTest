using Services.Models;
using Storage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Mappings
{
    public static class SiteMapping
    {
        public static SiteModel ToModel(this Site site)
        {
            if (site == null)
            {
                return null;
            }
            var advEventModel = new SiteModel
            {
                Id = site.Id,
                Url = site.Url,
                Banners = site.Banners?.Select(x => x.ToModel()).ToList()
            };
            return advEventModel;
        }
    }
}
