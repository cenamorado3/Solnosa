﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyWebsite.Models;

namespace MyWebsite.Controllers
{
    public class ContactFormsController : Controller
    {
        private WebsiteEntities db = new WebsiteEntities();

        // GET: ContactForms
        //public ActionResult Index()
        //{
        //    return View("Contact");
        //}

        public ActionResult Submitted()
        {
            return View();
        }

        public ActionResult Error()
        {
            return View();
        }

        // GET: ContactForms/Details/5
        //public ActionResult Details(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ContactForm contactForm = db.ContactForms.Find(id);
        //    if (contactForm == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(contactForm);
        //}

        // GET: ContactForms/Create
        public ActionResult Contact()
        {
            return View();
        }

        // POST: ContactForms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact([Bind(Include = "Email,Phone,Reason,Message")] ContactForm contactForm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.ContactForms.Add(new ContactForm
                    {
                        Email = contactForm.Email,
                        Phone = contactForm.Phone,
                        Reason = contactForm.Reason,
                        Seen = "N",
                        ContactDate = DateTime.Now.ToString(),
                        Message = contactForm.Message
                    });
                    db.SaveChanges();
                    return RedirectToAction("Submitted");
                }

                return View(contactForm);
            }

            catch(DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                        validationErrors.Entry.Entity.ToString(),
                        validationError.ErrorMessage);
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                //throw raise;
                return RedirectToAction("Error");
            }

        }



        //    // GET: ContactForms/Edit/5
        //    public ActionResult Edit(string id)
        //    {
        //        if (id == null)
        //        {
        //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //        }
        //        ContactForm contactForm = db.ContactForms.Find(id);
        //        if (contactForm == null)
        //        {
        //            return HttpNotFound();
        //        }
        //        return View(contactForm);
        //    }

        //    // POST: ContactForms/Edit/5
        //    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //    // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public ActionResult Edit([Bind(Include = "Email,Phone,Reason,Seen,ContactDate,Message")] ContactForm contactForm)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            db.Entry(contactForm).State = EntityState.Modified;
        //            db.SaveChanges();
        //            return RedirectToAction("Index");
        //        }
        //        return View(contactForm);
        //    }

        //    // GET: ContactForms/Delete/5
        //    public ActionResult Delete(string id)
        //    {
        //        if (id == null)
        //        {
        //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //        }
        //        ContactForm contactForm = db.ContactForms.Find(id);
        //        if (contactForm == null)
        //        {
        //            return HttpNotFound();
        //        }
        //        return View(contactForm);
        //    }

        //    // POST: ContactForms/Delete/5
        //    [HttpPost, ActionName("Delete")]
        //    [ValidateAntiForgeryToken]
        //    public ActionResult DeleteConfirmed(string id)
        //    {
        //        ContactForm contactForm = db.ContactForms.Find(id);
        //        db.ContactForms.Remove(contactForm);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    protected override void Dispose(bool disposing)
        //    {
        //        if (disposing)
        //        {
        //            db.Dispose();
        //        }
        //        base.Dispose(disposing);
        //    }
        //}
    }
}
