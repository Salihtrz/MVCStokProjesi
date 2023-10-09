using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStokProjesi.Models.Entity;

namespace MvcStokProjesi.Controllers
{
    public class SatisController : Controller
    {
        MvcDbStokEntities db = new MvcDbStokEntities(); //Modeli ve içindeki tabloları tutar
        // GET: Satis
        public ActionResult Index()
        {
			List<SelectListItem> urunler = (from i in db.Tbl_Urunler.ToList()
											 select new SelectListItem
											 {
												 Text = i.UrunAd,
												 Value = i.UrunID.ToString()
											 }).ToList();

			ViewBag.Urun = urunler; //degerler ' i tutuyor.

			List<SelectListItem> musteriler = (from i in db.Tbl_Musteriler.ToList()
											 select new SelectListItem
											 {
												 Text = i.MusteriAd,
												 Value = i.MusteriID.ToString()
											 }).ToList();
			ViewBag.Musteri = musteriler; //degerler ' i tutuyor.
			return View();
        }

        [HttpGet]
        public ActionResult YeniSatis()
        {
            List<SelectListItem> degerler = (from i in db.Tbl_Urunler.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.UrunAd,
												 Value = i.UrunID.ToString()
                                             }).ToList();

            ViewBag.Urun = degerler; //degerler ' i tutuyor.
			return View();
		}

        [HttpPost]
        public ActionResult YeniSatis(Tbl_Satislar p1)
        {
			db.Tbl_Satislar.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        } 
    }
}