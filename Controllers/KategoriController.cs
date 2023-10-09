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
    public class KategoriController : Controller
    {
        // GET: Kategori
        MvcDbStokEntities db = new MvcDbStokEntities(); //Modeli ve içindeki tabloları tutar
        public ActionResult Index(int sayfa=1)
        {
            //var degerler = db.Tbl_Kategoriler.ToList();
            var degerler = db.Tbl_Kategoriler.ToList().ToPagedList(sayfa,4);
            return View(degerler);
        }
        [HttpPost] //Sayfada butona basıldığında buradaki işlemi gerçekleştir.
        public ActionResult YeniKategori(Tbl_Kategoriler p1)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniKategori");
            }
            db.Tbl_Kategoriler.Add(p1);
            db.SaveChanges();
            return View();
        }

        [HttpGet] //Aksi durumda sayfada herhangi bir işlem yapılmazsa ve sayfa yüklenirse bir şey yapma sadece o sayfayı geri döndür.
        public ActionResult YeniKategori()
        {
            return View();
        }
        public ActionResult SIL(int id)
        {
            var kategori = db.Tbl_Kategoriler.Find(id);
            db.Tbl_Kategoriler.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGetir(int id)
        {
            var ktgr = db.Tbl_Kategoriler.Find(id);
            return View("KategoriGetir", ktgr);
        }
        public ActionResult Guncelle(Tbl_Kategoriler p1)
        {
            var ktgr = db.Tbl_Kategoriler.Find(p1.KategoriID);
            ktgr.KategoriAd = p1.KategoriAd;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}