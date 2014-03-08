using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FormatCurrency.Models;
using System.Globalization;

namespace FormatCurrency.Controllers
{
    public class CultureInfoController : Controller
    {
        private FormatCurrencyContext db = new FormatCurrencyContext();

        // GET: /CultureInfo/
        public ActionResult Index()
        {
            return View(db.IsoCultureInfoes.ToList());
        }

        public JsonResult List()
        {
            return Json(db.IsoCultureInfoes.ToList(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult FormattedText(string id)
        {
            try
            {
                string fare = "123000.0000";
                decimal parsed = decimal.Parse(fare, CultureInfo.InvariantCulture);
                CultureInfo cultureInfo = new CultureInfo(id);
                NumberFormatInfo cultureNFO = (NumberFormatInfo)cultureInfo.NumberFormat.Clone();
                //cultureNFO.CurrencySymbol = string.Empty;
                string text = string.Format(cultureNFO, "{0:c}", parsed);
                return Json(new { formattedCurrency = text });
            }
            catch (Exception ex)
            {
                return Json(new { formattedCurrency = "N/A" });
            }
        }
        // GET: /CultureInfo/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    IsoCultureInfo isocultureinfo = db.IsoCultureInfoes.Find(id);
        //    if (isocultureinfo == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(isocultureinfo);
        //}

        //// GET: /CultureInfo/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: /CultureInfo/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,LanguageCultureName,DisplayName,CultureCode,ISO639xValue")] IsoCultureInfo isocultureinfo)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.IsoCultureInfoes.Add(isocultureinfo);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(isocultureinfo);
        //}

        //// GET: /CultureInfo/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    IsoCultureInfo isocultureinfo = db.IsoCultureInfoes.Find(id);
        //    if (isocultureinfo == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(isocultureinfo);
        //}

        //// POST: /CultureInfo/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,LanguageCultureName,DisplayName,CultureCode,ISO639xValue")] IsoCultureInfo isocultureinfo)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(isocultureinfo).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(isocultureinfo);
        //}

        //// GET: /CultureInfo/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    IsoCultureInfo isocultureinfo = db.IsoCultureInfoes.Find(id);
        //    if (isocultureinfo == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(isocultureinfo);
        //}

        //// POST: /CultureInfo/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    IsoCultureInfo isocultureinfo = db.IsoCultureInfoes.Find(id);
        //    db.IsoCultureInfoes.Remove(isocultureinfo);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
