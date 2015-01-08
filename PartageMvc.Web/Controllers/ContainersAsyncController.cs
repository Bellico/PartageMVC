using PartageMvc.Web.Models;
using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PartageMvc.Web.Controllers
{
    public class ContainersAsyncController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ContainersAsync
        public async Task<ActionResult> Index()
        {
            return View(await db.Container.ToListAsync());
        }

        // GET: ContainersAsync/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Container container = await db.Container.FindAsync(id);
            if (container == null)
            {
                return HttpNotFound();
            }
            return View(container);
        }

        // GET: ContainersAsync/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContainersAsync/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,DataContentId,Name,Description,Link,ContentType,Visibility,DateOnline,DateExpire")] Container container)
        {
            if (ModelState.IsValid)
            {
                db.Container.Add(container);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(container);
        }

        // GET: ContainersAsync/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Container container = await db.Container.FindAsync(id);
            if (container == null)
            {
                return HttpNotFound();
            }
            return View(container);
        }

        // POST: ContainersAsync/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,DataContentId,Name,Description,Link,ContentType,Visibility,DateOnline,DateExpire")] Container container)
        {
            if (ModelState.IsValid)
            {
                db.Entry(container).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(container);
        }

        // GET: ContainersAsync/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Container container = await db.Container.FindAsync(id);
            if (container == null)
            {
                return HttpNotFound();
            }
            return View(container);
        }

        // POST: ContainersAsync/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Container container = await db.Container.FindAsync(id);
            db.Container.Remove(container);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

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
