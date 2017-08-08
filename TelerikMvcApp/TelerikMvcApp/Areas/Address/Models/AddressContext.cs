using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TelerikMvcApp.Areas.Address.Models
{
    public class AddressContext: DbContext
    {
        public DbSet<Address> Address { get; set; }
    }
}