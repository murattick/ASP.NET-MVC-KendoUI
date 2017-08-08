using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using TelerikMvcApp.Models;
using TelerikMvcApp.Areas.Address.Models;

namespace TelerikMvcApp.Controllers
{
    public class HomeController : Controller
    {
        private UserContext db = new UserContext();
        private AddressContext db2 = new AddressContext();

        public ActionResult Index()
        {
            ViewData["defaultDepatment"] = db.Departments.ToList();
            ViewData["defaultAddress"] = db2.Address.ToList();

            return View();
        }

        public ActionResult Users_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<User> users = db.Users;
            DataSourceResult result = users.ToDataSourceResult(request, user => new {
                Id = user.Id,
                Name = user.Name,
                DepartmentId = user.DepartmentId,
                AddressId = user.AddressId
            });

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Users_Create([DataSourceRequest]DataSourceRequest request, User user)
        {
            if (ModelState.IsValid)
            {
                var entity = new User
                {
                    Name = user.Name,
                    DepartmentId = user.DepartmentId,
                    AddressId = user.AddressId
                };

                db.Users.Add(entity);
                db.SaveChanges();
                user.Id = entity.Id;
            }

            return Json(new[] { user }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Users_Update([DataSourceRequest]DataSourceRequest request, User user)
        {
          
                var data = db.Users.Where(a => a.Id == user.Id).FirstOrDefault();
                data.Name = user.Name;
                data.DepartmentId = user.DepartmentId;
                data.AddressId = user.AddressId;

                db.Entry(data).State = EntityState.Modified;
                db.SaveChanges();
            

            return Json(new[] { user }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Users_Destroy([DataSourceRequest]DataSourceRequest request, int Id)
        {

                User data = db.Users.Where(a => a.Id == Id).FirstOrDefault();
                db.Users.Remove(data);
                db.SaveChanges();
            

            return Json("OK");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
