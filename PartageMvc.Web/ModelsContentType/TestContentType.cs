using PartageMvc.Web.Manager;
using PartageMvc.Web.Core;
using System;

namespace PartageMvc.Web.ModelsContentType
{
    [ContentType(Key = "test", Name = "TestContent", CreateView = "TestContent.View", Description = "Creer un contenu de test pour tester")]
    public class TestContentType : ContentType, IContentType
    {
         public string Test { get; set; }

         public IContentManager GetManager()
         {
             return new TestContentTypeManager(this);
         }

         public void SetContainer(Models.Container container)
         {
             this.Container = container;
         }
    }
}