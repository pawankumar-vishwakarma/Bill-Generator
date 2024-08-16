using BillGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BillGenerator.Controllers
{
    public class BGController : Controller
    {
        // GET: BG
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(BillDetails details)
        {
            return ;
        }
    }
}