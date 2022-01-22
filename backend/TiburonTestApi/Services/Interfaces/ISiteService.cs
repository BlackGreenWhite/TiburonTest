using Microsoft.AspNetCore.Mvc;
using Services.Models;
using Storage.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ISiteService: ICRUD<Site, SiteModel>
    {
        Task<SiteModel> GetByUrl(string url);
    }
}
