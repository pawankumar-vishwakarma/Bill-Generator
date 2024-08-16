using BillGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BillGenerator.Repository;

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
            Data data = new Data();
            data.saveBillDetails(details);
            ModelState.Clear();
            return View();
        }

       
        public ActionResult CreateItem(Items item)
        {
            return PartialView("_CreateItem", item);
        }
    }
}