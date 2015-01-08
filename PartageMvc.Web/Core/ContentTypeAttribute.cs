using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartageMvc.Web.Core
{
    public class ContentTypeAttribute : Attribute
    {
        public string Key { get; set; }
        public string Name { get; set; }
    }
}