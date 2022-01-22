using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Storage.Models
{
    public class SiteBanner
    {
        [Required]
        public long Id { get; set; }
        public Site Site { get; set; }
        public long SiteId { get; set; }
        public Banner Banner { get; set; }
        public long BannerId { get; set; }
    }
}
