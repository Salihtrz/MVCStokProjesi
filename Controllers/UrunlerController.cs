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
    public class UrunlerController : Controller
    {
        // GET: Urunler
        MvcDbStokEntities db = new MvcDbStokEntities();//Modeli ve içindeki tabloları tutar
        public ActionResult Index(int sayfa=1)
        {
            //var degerler = db.Tbl_Urunler.ToList();4
            var degerler = db.Tbl_Urunler.ToList().ToPagedList(sayfa,5);
            return View(degerler);
        }
        [HttpPost]//Sayfada butona basıldığında buradaki işlemi gerçekleştir.
        public ActionResult YeniUrun(Tbl_Urunler p1)
        {
            var ktgr = db.Tbl_Kategoriler.Where(m => m.KategoriID == p1.Tbl_Kategoriler.KategoriID).FirstOrDefault();
            p1.Tbl_Kategoriler = ktgr;
            db.Tbl_Urunler.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]//Aksi durumda sayfada herhangi bir işlem yapılmazsa ve sayfa yüklenirse bir şey yapma sadece o sayfayı geri döndür.
        public ActionResult YeniUrun()
        {
            //Tbl_Kategoriler 'den KategoriAd ve KategoriID 'leri i değişkenine çektik ve bunları degerler değişkenine attık. 
            List<SelectListItem> degerler = (from i in db.Tbl_Kategoriler.ToList() 
                                             select new SelectListItem
                                             {
                                                 Text = i.KategoriAd,
                                                 Value = i.KategoriID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler; //degerler ' i tutuyor.
            return View();
        }
        public ActionResult SIL(int id)
        {
            var urun = db.Tbl_Urunler.Find(id);
            db.Tbl_Urunler.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGetir(int id)
        {
            var urn = db.Tbl_Urunler.Find(id);

            //Tbl_Kategoriler 'den KategoriAd ve KategoriID 'leri i değişkenine çektik ve bunları degerler değişkenine attık. 
            List<SelectListItem> degerler = (from i in db.Tbl_Kategoriler.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KategoriAd,
                                                 Value = i.KategoriID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler; //degerler ' i tutuyor.

            return View("UrunGetir", urn);
        }
        public ActionResult Guncelle(Tbl_Urunler p1)
        {
            var urun = db.Tbl_Urunler.Find(p1.UrunID);
            urun.UrunAd = p1.UrunAd;
            //urun.Urunkategori = p1.Urunkategori;
            urun.Marka = p1.Marka;
            urun.Fiyat = p1.Fiyat;
            urun.Stok = p1.Stok;
            var ktgr = db.Tbl_Kategoriler.Where(m => m.KategoriID == p1.Tbl_Kategoriler.KategoriID).FirstOrDefault();
            urun.Urunkategori = ktgr.KategoriID;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}