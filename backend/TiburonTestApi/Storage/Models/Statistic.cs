using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Storage.Models
{
    public class Statistic
    {
        [Required]
        public long Id { get; set; }
        public User User { get; set; }
        public long UserId { get; set; }
        public SiteBanner SiteBanner { get; set; }
        public long SiteBannerId { get; set; }
        public AdvEventsEnum AdvEvent { get; set; }
    }
}
