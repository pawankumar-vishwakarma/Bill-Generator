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

       
        //public ActionResult CreateItem(Items item)
        //{
        //    return PartialView("_CreateItem", item);
        //}

        [HttpPost]
        public ActionResult CreateItem(string productName, int price, int qty, int itemIndex)
        {
            // Verify that qty is passed as expected
            if (qty == 0)
            {
                // Add some logging or breakpoint to check why qty is 0
            }

            // Create the item
            var item = new Items
            {
                ProductName = productName,
                Price = price,
                Quantity = qty,  // Make sure this receives the correct value
                ItemIndex = itemIndex
            };

            return PartialView("_CreateItem", item);
        }
    }
}