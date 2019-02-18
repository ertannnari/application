using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCUygulama.Models;
using System.Web.Mvc;
using MVCUygulama.DAL;

namespace MVCUygulama.Controllers
{
    
    public class YazarController : Controller
    {   // GET: Yazar
        public ActionResult Index()
        {
            //veritabanını çağırmak için
            using (Context context = new Context())
            {
                //kayıtları listeleme
                var userItem = context.MYazars.Where(m=>m.isDeleted!=true).ToList();
               // var userItem1 = context.kitaps.ToList();
                return View(userItem);
                
            }
        }
        public ActionResult CreateOrUpdate( int? id)
        {
            var userItem=new MYazar();
           
            if (id!=null)
            {
                using (Context context = new Context())
                { 
                    //yazarid eşit id ve silinmemişse
                    userItem = context.MYazars.FirstOrDefault(m => m.YazarID == (int)id && m.isDeleted!=true);
                    return View(userItem);
                }
            }
            return View();
        }

        [HttpPost]
        public ActionResult CreateOrUpdate(MYazar model)
        {
            if (model.YazarID != 0)
            {
                //YazarID 0 değilse idler eşit ise gerekli alanları güncelleştir
                using (Context context = new Context())
                {
                    MYazar old = context.MYazars.FirstOrDefault(oldd => oldd.YazarID == model.YazarID);

                    old.YazarAD = model.YazarAD;
                    old.MakaleSayisi = model.MakaleSayisi;
                    context.SaveChanges();
                    return RedirectToAction("Index", "Yazar");
                }
            }
            else
            {
                //YazarID 0 ise yeni bir kayıt ekle
                using (Context context = new Context())
                {
                    context.MYazars.Add(model);
                    context.SaveChanges();
                    return RedirectToAction("Index", "Yazar");
                }
            }
        }
        
        public ActionResult Delete(int? id)
        {
            if (id != null)
            {
                //Id boş değilse 
                using (Context context = new Context())
                {
                    MYazar old = context.MYazars.FirstOrDefault(oldd => oldd.YazarID == (int)id && oldd.isDeleted!=true);
                    if (old != null) { 
                    old.isDeleted = true;
                    context.SaveChanges();
                    }
                    return RedirectToAction("Index", "Yazar");
                }
            }
            return View();
        }
        public ActionResult goruntule(int? id)
        {
            using (Context context = new Context())
            {
                var userItem = context.kitaps.Where(m => m.YazarID == id).ToList();
                return View(userItem);
            }
                
        }
        }
    }
