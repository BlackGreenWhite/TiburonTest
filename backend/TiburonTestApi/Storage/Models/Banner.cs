using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Storage.Models
{
    public class Banner
    {
        [Required]
        public long Id { get; set; }
        public string BannerName { get; set; }
        public string BannerUrl { get; set; }
    }
}
