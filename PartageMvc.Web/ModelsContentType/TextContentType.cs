using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using PartageMvc.Web.Core;
using PartageMvc.Web.Manager;
using PartageMvc.Web.Models;
using System.ComponentModel.DataAnnotations;

namespace PartageMvc.Web.ModelsContentType
{
    [ContentType(Key = "text", Name = "Texte", CreateView = "TextContent.Create", DisplayView = "TextContent.Display", Description = "Un simple Texte à partager")]
    public class TextContentType : ContentType, IContentType
    {
        [Display(Name = "Texte")]
        [Required]
        public string Text { get; set; }

        //[NotMapped]
        //private IContentBehavior Manager = new TextContentTypeBehavior(); 

        public IContentManager GetManager()
        {
            return new TextContentTypeManager(this); 
        }

        public void SetContainer(Container container)
        {
            this.Container = container;
        }
    }
}