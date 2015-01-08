
using PartageMvc.Web.Models;
namespace PartageMvc.Web.Core
{
    public interface IContentType
    {
        IContentBehavior GetManager();
        string GetViewContent();
    }
}
