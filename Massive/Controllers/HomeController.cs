using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Massive.Controllers
{
    public class HomeController : Controller
    {
        DynamicModel comments = null;

        public HomeController()
        {
            comments = new DynamicModel(connectionStringName: "ajh", tableName: "Comment", primaryKeyField: "Id");
        }

        public ActionResult Index()
        {
            var c = comments.All();

            return View(c);
        }

        [HttpPost]
        public ActionResult Index(string message, bool? cool, int? age = 0)
        {
            var comment = new { 

                Message = message, 
                Cool = cool.Value,
                Age = age,
                CreatedOn = DateTime.Now 
            };

            comments.Save(comment);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            comments.Delete(key: id);
            return RedirectToAction("Index");
        }
    }
}
