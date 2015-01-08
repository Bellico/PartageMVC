using PartageMvc.Web.Behaviors;
using PartageMvc.Web.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PartageMvc.Web.ModelsContentType
{
    [ContentType (Key = "text", Name = "Texte")]
    public class TextContentType : ContentType, IContentType
    {
        [Display(Name = "Texte")]
        [Required]
        public string Text { get; set; }

        [NotMapped]
        private IContentBehavior Manager = new TextContentTypeBehavior(); 

        public IContentBehavior GetManager()
        {
            return Manager;
        }

        public string GetViewContent()
        {
            return "TextContentView";
        }

    }
}