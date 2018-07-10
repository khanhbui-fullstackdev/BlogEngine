using BlogEngine.Model.Models;
using BlogEngine.Service.IServices;
using BlogEngine.Web.Infrastructure.Extensions;
using BlogEngine.Web.ViewModels;
using BotDetect.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace BlogEngine.Web.Controllers
{
    public class AboutController : Controller
    {
        private IContactService _contactService;

        public AboutController(IContactService contactService)
        {
            this._contactService = contactService;
        }

        // GET: About
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [CaptchaValidation("captchaCode", "ContactCaptcha", "Incorrect CAPTCHA code!")]
        public JsonResult AddContact(string contactInfo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    MvcCaptcha mvcCaptcha = new MvcCaptcha("captchaCode");

                    var contactViewModel = new JavaScriptSerializer().Deserialize<ContactViewModel>(contactInfo);
                    Contact contact = new Contact();
                    contact.UpdateContact(contactViewModel);
                    _contactService.AddContact(contact);
                    _contactService.SaveChanges();

                    return Json(new
                    {
                        status = true
                    });
                }
                return Json(new
                {
                    status = false
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    status = false,
                    error = ex.InnerException.Message
                });
            }
        }
    }
}