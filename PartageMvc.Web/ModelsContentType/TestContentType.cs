using PartageMvc.Web.Behaviors;
using PartageMvc.Web.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartageMvc.Web.ModelsContentType
{
    [ContentType (Key = "test")]
    public class TestContentType : ContentType, IContentType
    {
         public string Test { get; set; }

         public IContentBehavior GetManager()
         {
             return new TestContentTypeBehavior();
         }

         public string GetViewContent()
         {
             return "TestContentView";
         }
    }
}