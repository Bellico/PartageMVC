using PartageMvc.Web.Core;
using PartageMvc.Web.Models;
using System.Threading.Tasks;

namespace PartageMvc.Web.Core
{
    public interface IContentManager
    {
        Task<Container> CreateAsync();

        IContentType FindById(string id);

        void Execute(string key);
    }
}