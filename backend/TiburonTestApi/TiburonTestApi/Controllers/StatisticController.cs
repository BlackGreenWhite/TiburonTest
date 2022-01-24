using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Storage.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using TiburonTestApi.Models;
using System;
using System.Linq;
using System.Threading;

namespace TiburonTestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IBannerService _bannerService;
        private readonly ISiteService _siteService;
        private readonly ISiteBannerService _siteBannerService;
        private readonly IStatisticService _statisticService;
        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);
        public StatisticController(IUserService userService, IBannerService bannerService, ISiteService siteService, ISiteBannerService siteBannerService, IStatisticService statisticService)
        {
            _userService = userService;
            _bannerService = bannerService;
            _siteService = siteService;
            _siteBannerService = siteBannerService;
            _statisticService = statisticService;
        }

        [HttpPost]
        public async Task<ActionResult<Statistic>> Create(StatisticRequest statisticRequest)
        {
            await _semaphore.WaitAsync();
            try
            {
                var formatedUrl = new Uri(statisticRequest.SiteUrl).AbsoluteUri;
                var user = await _userService.GetByIp(statisticRequest.UserIP) ?? await _userService.Create(new User { UserIP = statisticRequest.UserIP });
                var banner = await _bannerService.GetByName(statisticRequest.BannerName) ?? await _bannerService.Create(new Banner { BannerName = statisticRequest.BannerName });
                var site = await _siteService.GetByUrl(formatedUrl) ?? await _siteService.Create(new Site { Url = formatedUrl });
                var siteBanner = await _siteBannerService.GetBySiteAndBanner(banner.Id, site.Id) ?? await _siteBannerService.Create(new SiteBanner { SiteId = site.Id, BannerId = banner.Id });
                var statistic = await _statisticService.GetByUserAndSiteBanner(user.Id, siteBanner.Id)
                    ?? await _statisticService.Create(new Statistic { UserId = user.Id, SiteBannerId = siteBanner.Id, AdvEvent = statisticRequest.AdvEventsEnum });
                if (statisticRequest.AdvEventsEnum > statistic.AdvEvent)
                {
                    var statisticReplacer = new Statistic { Id = statistic.Id, UserId = statistic.UserId, SiteBannerId = statistic.SiteBannerId, AdvEvent = statisticRequest.AdvEventsEnum };
                    await _statisticService.Update(statisticReplacer);
                }
                var result = _statisticService.GetById(statistic.Id);
                return Ok(result);
            }
            finally
            {
                _semaphore.Release();
            }
        }
        [HttpGet("onSite")]
        public async Task<ActionResult<IReadOnlyCollection<Statistic>>> GetAllOnSite(string siteUrl)
        {
            if (siteUrl != null && siteUrl != "")
            {
                var response = new List<StatisticOnSiteResponse>();
                var site = await _siteService.GetByUrl(siteUrl);
                if (site == null) return Ok("Site is empty");

                var siteId = site.Id;
                var statistics = await _statisticService.GetAllOnSite(siteId);

                foreach (var statistic in statistics)
                {
                    var user = await _userService.GetById(statistic.UserId);
                    var siteBanner = await _siteBannerService.GetById(statistic.SiteBannerId);
                    var banner = await _bannerService.GetById(siteBanner.BannerId);
                    response.Add(new StatisticOnSiteResponse { UserIP = user.UserIP, BannerName = banner.BannerName, AdvEventsEnum = statistic.AdvEvent.ToString() });
                }
                return Ok(response);
            }
            return BadRequest();
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyCollection<Statistic>>> GetAll()
        {
            var statistics = await _statisticService.GetAll();
            return Ok(statistics);
        }
    }
}
