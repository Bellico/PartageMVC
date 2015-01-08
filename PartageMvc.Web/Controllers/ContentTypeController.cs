using PartageMvc.Web.Core;
using PartageMvc.Web.Models;
using PartageMvc.Web.ModelsContentType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PartageMvc.Web.Controllers
{
    public class ContentTypeController : Controller
    {
        [Route("Create/{type?}")]
        public ActionResult Create(string type)
        {
            IContentType contentType;

            if (type == null) contentType = ContentTypeProvider.Default();
            else
            {
                try
                {
                    contentType = ContentTypeProvider.GetContentType(type);
                }
                catch (IndexOutOfRangeException)
                {
                    return HttpNotFound();
                }
            }

            return View(contentType.GetViewContent());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Create")]
        public ActionResult PostCreate(string type)
        {
            if (type == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            try
            {
                var contentType = ContentTypeProvider.GetContentType(type);
                ContentTypeProvider.Bind(contentType, Request.Form);
                ModelState.Clear();
                TryValidateModel(contentType);
                if (ModelState.IsValid)
                {
                    contentType.GetManager().Create();
                }
                return View(contentType.GetViewContent());
            }
            catch (IndexOutOfRangeException)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }
    }
}