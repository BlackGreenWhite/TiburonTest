using Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Models
{
    public class StatisticModel
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long SiteBannerId { get; set; }
        public AdvEventsEnum AdvEvent { get; set; }
    }
}
