using BlogEngine.Model.Models;
using BlogEngine.Service.IServices;
using BlogEngine.Web.Infrastructure.Extensions;
using BlogEngine.Web.ViewModels;
using BotDetect.Web;
using BotDetect.Web.Mvc;
using BotDetect.Web.UI;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.UI;

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

        [HttpGet]
        [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
        public JsonResult CheckCaptcha(string captchaId, string instanceId, string userInput)
        {
            bool ajaxValidationResult = Captcha.AjaxValidate(captchaId, userInput, instanceId);
            return Json(ajaxValidationResult, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddContact(string contactInfo)
        {
            var errorMessage = string.Empty;
            try
            {
                var contactViewModel = new JavaScriptSerializer().Deserialize<ContactViewModel>(contactInfo);
                
                if (ModelState.IsValid)
                {
                    Contact contact = new Contact();
                    contact.UpdateContact(contactViewModel);
                    _contactService.AddContact(contact);
                    _contactService.SaveChanges();

                    return Json(new
                    {
                        status = true
                    });
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.InnerException.Message;
            }
            return Json(new
            {
                status = false,
                error = errorMessage
            });
        }


        //[HttpPost]
        //[CaptchaValidation("CaptchaCode", "ContactCaptcha", "Incorrect CAPTCHA code!")]
        //public ActionResult AddContact(ContactViewModel contactViewModel)
        //{
        //    var errorMessage = string.Empty;
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            MvcCaptcha mvcCaptcha = new MvcCaptcha("CaptchaCode");
        //            mvcCaptcha.Reset();
        //            Contact contact = new Contact();
        //            contact.UpdateContact(contactViewModel);
        //            _contactService.AddContact(contact);
        //            _contactService.SaveChanges();
        //        }
        //        return View("Index");
        //    }
        //    catch (DbEntityValidationException dbEx)
        //    {
        //        Exception raise = dbEx;
        //        foreach (var validationErrors in dbEx.EntityValidationErrors)
        //        {
        //            foreach (var validationError in validationErrors.ValidationErrors)
        //            {
        //                string message = string.Format("{0}:{1}",
        //                    validationErrors.Entry.Entity.ToString(),
        //                    validationError.ErrorMessage);
        //                // raise a new exception nesting  
        //                // the current instance as InnerException  
        //                raise = new InvalidOperationException(message, raise);
        //            }
        //        }
        //        throw new Exception(raise.Message);
        //    }

        //}
    }
}