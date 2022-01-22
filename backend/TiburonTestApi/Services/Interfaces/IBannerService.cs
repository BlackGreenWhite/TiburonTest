using Microsoft.AspNetCore.Mvc;
using Services.Models;
using Storage.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IBannerService: ICRUD<Banner, BannerModel>
    {
        Task<BannerModel> GetByName(string name);
    }
}
