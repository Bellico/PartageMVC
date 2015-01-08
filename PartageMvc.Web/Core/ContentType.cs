using PartageMvc.Web.Models;

namespace PartageMvc.Web
{
    public class ContentType
    {
        private Container Container;

        public ContentType()
        {

        }

        public ContentType(Container container)
            : this()
        {
            this.Container = container;
        }
    }
}
