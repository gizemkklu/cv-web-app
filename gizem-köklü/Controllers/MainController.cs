using gizem_köklü.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace gizem_köklü.Controllers
{
    public class MainController : Controller
    {
        CvDbEntities1 db = new CvDbEntities1();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            List<about> aboutList = db.about.ToList();

            int yarisi = db.yetenekler.Count() / 2;

            List<yetenekler> ilkYarisi = db.yetenekler.OrderBy(y => y.id).Take(yarisi).ToList();
            List<yetenekler> geriKalan = db.yetenekler.OrderBy(y => y.id).Skip(yarisi).ToList();
            List<ilgiler> ilgiler = db.ilgiler.ToList();
            

            ViewBag.skillListIlkYarisi = ilkYarisi;
            ViewBag.skillListGeriKalan = geriKalan;
            ViewBag.ilgiler = ilgiler;

            
            ViewBag.ProjectCount = db.projects.Count();
            ViewBag.sertifica = db.sertifikalar.Count();
            ViewBag.skills = db.yetenekler.Count();
            return View(aboutList);
        }

        public ActionResult Resume()
        {
            return View();
        }

        public ActionResult Portfolio()
        {
            List<projects> list = db.projects.ToList();

            return View(list);
        }

        public ActionResult PortfolioDetayPage(int? id)
        {
            var item = db.projects.Where(x => x.id == id).ToList();
           
            return View(item);
        }

    }
}