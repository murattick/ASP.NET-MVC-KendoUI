using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TelerikMvcApp.Areas.Address.Models
{
    public class Address
    {
        public int AddressId { get; set; }
        public string City { get; set; }
    }
}