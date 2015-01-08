using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PartageMvc.Web;
using PartageMvc.Web.ModelsContentType;

namespace PartageMvc.Tests
{
    [TestClass]
    public class Utils
    {
        [TestMethod]
        public void getContentType_text_text()
        {
            var type = ContentTypeProvider.GetContentType("text");
            Assert.IsInstanceOfType(type, typeof(TextContentType));
        }
    }
}
