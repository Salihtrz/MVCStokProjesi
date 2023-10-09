using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStokProjesi.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace MvcStokProjesi.Controllers
{
    public class MusterilerController : Controller
    {
        // GET: Musteriler
        MvcDbStokEntities db = new MvcDbStokEntities();//Modeli ve içindeki tabloları tutar
        public ActionResult Index(int sayfa = 1)
        {
            //var degerler = db.Tbl_Musteriler.ToList();
            
            //return View("Index");
            
            var degerler = from d in db.Tbl_Musteriler select d;
            return View(degerler.ToList());
        }
        [HttpPost]//Sayfada butona basıldığında buradaki işlemi gerçekleştir.
        public ActionResult YeniMusteri(Tbl_Musteriler p1)
        {
            db.Tbl_Musteriler.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index","Musteriler");
        }
        [HttpGet]//Aksi durumda sayfada herhangi bir işlem yapılmazsa ve sayfa yüklenirse bir şey yapma sadece o sayfayı geri döndür.
        public ActionResult YeniMusteri()
        {
            return View();
        }
        public ActionResult SIL(int id)
        {
            var musteri = db.Tbl_Musteriler.Find(id);
            db.Tbl_Musteriler.Remove(musteri);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriGuncelle(int id)
        {
            var mstr = db.Tbl_Musteriler.Find(id);
            return View("MusteriGuncelle", mstr);
        }
        public ActionResult Guncelle(Tbl_Musteriler p1)
        {
            var mstr = db.Tbl_Musteriler.Find(p1.MusteriID);
            mstr.MusteriAd = p1.MusteriAd;
            mstr.MusteriSoyad = p1.MusteriSoyad;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}