using PartageMvc.Web.Core;
using PartageMvc.Web.Models;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PartageMvc.Web.Controllers
{
    public class ContentTypeController : Controller
    {
        [Route("Create/{type?}")]
        public ActionResult Create(string type)
        {
            IContentType contentType;

            if (type == null) contentType = ContentType.Default();
            else
            {
                try
                {
                    contentType = ContentType.GetContentType(type);
                }
                catch (IndexOutOfRangeException)
                {
                    return HttpNotFound();
                }
            }

            return View(ContentType.GetCreateView(contentType));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Create", Name = "Create")]
        public async Task<ActionResult> PostCreate(string type)
        {
            if (type == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            try
            {
                var contentType = ContentType.GetContentType(type);
                ContentType.Bind(contentType, Request.Form);
                ModelState.Clear();
                TryValidateModel(contentType);

                if (ModelState.IsValid)
                {
                    Container container = await contentType.GetManager().CreateAsync();
                    return RedirectToAction("DisplayContent", new { link = container.Link });
                }
                else
                {
                    return View(ContentType.GetCreateView(contentType));
                }
            }
            catch (IndexOutOfRangeException)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        [Route("View/{link}")]
        public ActionResult DisplayContent(string link)
        {
            if (link == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            using (var db = new ApplicationDbContext())
            {
                Container container = db.Container.Where(c => c.Link == link).FirstOrDefault();
                if (container == null)
                {
                    return HttpNotFound();
                }
                var contentType = ContentType.GetContentType(container);

                return View(ContentType.GetDisplayView(contentType), contentType);
            }
        }
    }
}