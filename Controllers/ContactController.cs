using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyWebsite.Models;


namespace MyWebsite.Controllers
{
    public class ContactController : Controller
    {
        private WebsiteEntities db = new WebsiteEntities();

        // GET: Contact
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create([Bind(Include = "Email,Phone,Reason,Message")] ContactForm contactForm)
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
            }

            return View();
        }
    }
}