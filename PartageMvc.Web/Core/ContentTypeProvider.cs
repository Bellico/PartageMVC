using PartageMvc.Web.Core;
using PartageMvc.Web.Models;
using PartageMvc.Web.ModelsContentType;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection;
using System.Web;

namespace PartageMvc.Web
{
    public class ContentTypeProvider
    {
        private static Type[] contentTypeEnable = new Type[]
        {
             typeof(TextContentType),
             typeof(TestContentType)
        };

        public static IContentType GetContentType(Container container)
        {
            //new TextContentType(Object);
            throw new NotImplementedException();
        }

        public static IContentType Default()
        {
            return new TextContentType();
        }

        public static IContentType GetContentType(string key)
        {
            foreach (Type type in contentTypeEnable)
            {
               var attr = Attribute.GetCustomAttributes(type, typeof(ContentTypeAttribute));
               ContentTypeAttribute contentTypeAttr = (ContentTypeAttribute) attr[0];
               if (contentTypeAttr.Key == key) return (IContentType)Activator.CreateInstance(type);
            }

            throw new IndexOutOfRangeException();
        }

        public static IContentType Bind(IContentType contentType, NameValueCollection paramater)
        {
            Type type = contentType.GetType();
            foreach (string param in paramater)
            {
                PropertyInfo property = type.GetProperty(param);
                if (property != null)
                {
                    string value = paramater.Get(param);
                    property.SetValue(contentType, value);
                }
            }
            return contentType;
        }
    }
}