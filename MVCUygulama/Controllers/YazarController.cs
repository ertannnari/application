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
        public ActionResult CreateOrUpdateKitap(int? yazarid,int? makaleid)
        {
            var userItem = new kitap();
            
            if (yazarid != null)
            {
                using (Context context = new Context())
                {
                    //makaleid boşsa yalnızca yazaridsini getir değilse tüm bilgileri getir
                    if (makaleid == null)
                    {
                        userItem.YazarID = (int)yazarid;
                       
                    }
                   else
                    {
                        userItem = context.kitaps.FirstOrDefault(m => m.makaleId == (int)makaleid);

                    }
                    return View(userItem);
                }
            }
            return View();
        }

        [HttpPost]
        public ActionResult CreateOrUpdateKitap(kitap model)
        {
            if (model.makaleId != 0)
            {
                using (Context context = new Context())
                {
                    kitap old = context.kitaps.FirstOrDefault(oldd => oldd.makaleId == model.makaleId);
                    old.YazarID = model.YazarID;
                    old.makaleAdi = model.makaleAdi;
                    
                    context.SaveChanges();
                    return RedirectToAction("Index", "Yazar");
                }
               
            }
            else
            {

                //kitapid 0 ise yeni bir kayıt ekle
                model.YazarID = int.Parse(Session["id"].ToString());
               
                using (Context context = new Context())
                {


                    context.kitaps.Add(model);
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
        public ActionResult goruntule(int? id,string ad)
        {
            
            using (Context context = new Context())
            {
                Session["id"] = id;
                Session["ad"] = ad;
                var userItem = context.kitaps.Where(m => m.YazarID == id && m.isDeleted != true).ToList();
                return View(userItem);
            }
                
        }
        public ActionResult DeleteKitap(int? id)
        {
            if (id != null)
            {
                //Id boş değilse 
                using (Context context = new Context())
                {
                    kitap old = context.kitaps.FirstOrDefault(oldd => oldd.makaleId == (int)id && oldd.isDeleted != true);
                    if (old != null)
                    {
                        old.isDeleted = true;
                        context.SaveChanges();
                    }
                    return RedirectToAction("Index", "Yazar");
                }
            }
            return View();
        }
    }
    }
