using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace TelerikMvcApp.Areas.Address.Models
{
    public class AddressDataInitializer: DropCreateDatabaseAlways<AddressContext>
    {
        protected override void Seed(AddressContext context)
        {
            context.Address.Add(new Address { AddressId = 1, City = "Stupino" });
            context.Address.Add(new Address { AddressId = 2, City = "Moscow" });
            base.Seed(context);
        }
    }
}