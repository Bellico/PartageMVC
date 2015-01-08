using MongoDB.Bson;
using MongoDB.Driver;
using PartageMvc.Web.Core;
using PartageMvc.Web.Models;
using PartageMvc.Web.ModelsContentType;
using System;
using System.Threading.Tasks;


namespace PartageMvc.Web.Manager
{
    public class TextContentTypeManager : IContentManager
    {
        ApplicationDbContext context = new ApplicationDbContext();
        MongoCollection<TextContentType> mongoCollection = MongoRepository.Open<TextContentType>("textContentCollection");

        private TextContentType model;

        public TextContentTypeManager(TextContentType model)
        {
            this.model = model;
        }

        public async Task<Container> CreateAsync()
        {
            var entity = mongoCollection.Insert(model);
            Container container = Container.Create(model.Id.ToString(), model);
            context.Container.Add(container);
            await context.SaveChangesAsync();
            
            return container;
        }

        public void Execute(string key)
        {
            throw new NotImplementedException();
        }

        public IContentType FindById(string id)
        {
            return mongoCollection.FindOneById(ObjectId.Parse(id));
        }
    }
}