using Microsoft.VisualStudio.TestTools.UnitTesting;
using PartageMvc.Web.Core;
using PartageMvc.Web.ModelsContentType;

namespace PartageMvc.Tests
{
    [TestClass]
    public class Utils
    {
        [TestMethod]
        public void getContentType_text_text()
        {
            var type = ContentType.GetContentType("text");
            Assert.IsInstanceOfType(type, typeof(TextContentType));
        }
    }
}
