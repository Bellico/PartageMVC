
using PartageMvc.Web.Models;
namespace PartageMvc.Web.Core
{
    public interface IContentType
    {
        IContentManager GetManager();

        void SetContainer(Container container);
    }
}
