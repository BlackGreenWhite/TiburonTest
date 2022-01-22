using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Storage.Models
{
    public class Site
    {
        [Required]
        public long Id { get; set; }
        public string Url {get;set; }
        public IReadOnlyCollection<Banner> Banners { get; set; }

    }
}
