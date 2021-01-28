using PopulatingDependentDropdownListFromDb.Models;
using PopulatingDependentDropdownListFromDb.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PopulatingDependentDropdownListFromDb.Controllers
{
    public class HomeController : Controller
    {
        private Db db = new Db();
        public ActionResult Index()
        {   
            List<SelectListItem> countyNames = new List<SelectListItem>();
            CountySubCountyWardRepo countyRepo = new CountySubCountyWardRepo();

            List<county> counties = db.county.ToList();
            counties.ForEach(x =>
            {
                countyNames.Add(new SelectListItem { Text = x.countyName, Value = x.id.ToString() });
            });
            countyRepo.countyNames = countyNames;
            return View(countyRepo);        
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult GetSubCounty(string countyId)
        {
            int cntyId;
            List<SelectListItem> subCountyNames = new List<SelectListItem>();
            if (!string.IsNullOrEmpty(countyId))
            {
                cntyId = Convert.ToInt32(countyId);
                List<subCounty> subCounties = db.subCounty.Where(x => x.countyId == cntyId).ToList();
                subCounties.ForEach(x =>
                {
                    subCountyNames.Add(new SelectListItem { Text = x.subCountyName, Value = x.id.ToString() });
                });
            }
            return Json(subCountyNames, JsonRequestBehavior.AllowGet);
        }
    }
}