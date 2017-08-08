using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace TelerikMvcApp.Models
{
    public class UserDbInitializer: DropCreateDatabaseAlways<UserContext>
    {
        protected override void Seed(UserContext context)
        {
            context.Users.Add(new User { Name = "Alex", DepartmentId = 1, AddressId = 1});
            context.Users.Add(new User { Name = "Vasya", DepartmentId = 2, AddressId = 2});

            context.Departments.Add( new Department { DepartmentId = 1, Title = "IT" });
            context.Departments.Add(new Department { DepartmentId = 2, Title = "HR" });

            base.Seed(context);
        }
    }
}