using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_WorkFlow.Areas.WorkFlow.Models;


namespace Project_WorkFlow.Areas.WorkFlow.Controllers
{
    public class HomeController : Controller
    {
        // GET: WorkFlow/Home
        public ActionResult Index(UserModel model)
        {
            return View(model);
        }
    }
}