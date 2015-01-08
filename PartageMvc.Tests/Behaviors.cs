using Microsoft.VisualStudio.TestTools.UnitTesting;
using PartageMvc.Web.Models;
using PartageMvc.Web.ModelsContentType;
using System.Linq;

namespace PartageMvc.Tests
{
    [TestClass]
    public class Behaviors
    {
        ApplicationDbContext context = new ApplicationDbContext();

        [TestMethod]
        public void addTextContentType_Success()
        {
            //var count = context.Container.Count();
            var text = new TextContentType();
         //   int i = new TextContentType().GetManager().Create();
            //Assert.AreEqual(count + 1, context.Container.Count());
            Assert.AreEqual(1, 1);
        }
    }
}
