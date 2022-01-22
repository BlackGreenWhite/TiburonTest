using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Storage.Models
{
    public class User
    {
        [Required]
        public long Id { get; set; }
        public string UserIP { get; set; }
    }
}
