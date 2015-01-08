using PartageMvc.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace PartageMvc.Web.Behaviors
{
    public class TextContentTypeBehavior : IContentBehavior
    {
        ApplicationDbContext context = new ApplicationDbContext();

        public int Create()
        {
            Container container = new Container();
            context.Container.Add(container);
            return  context.SaveChanges();
        }
    }
}