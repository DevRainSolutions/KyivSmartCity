

using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using DevRainSolutions.KyivSmartCity.New.Models;

namespace DevRainSolutions.KyivSmartCity.New.Areas.Admin.Models
{ 
    public class DocumentRepository : IDocumentRepository
    {
        KyivSmartCityNewContext context = new KyivSmartCityNewContext();

        public IQueryable<Document> All
        {
            get { return context.Documents; }
        }

        public IQueryable<Document> AllIncluding(params Expression<Func<Document, object>>[] includeProperties)
        {
            IQueryable<Document> query = context.Documents;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Document Find(int id)
        {
            return context.Documents.Find(id);
        }

        public void InsertOrUpdate(Document document)
        {
            if (document.Id == default(int)) {
                // New entity
                context.Documents.Add(document);
            } else {
                // Existing entity
                context.Entry(document).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var document = context.Documents.Find(id);
            context.Documents.Remove(document);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Dispose() 
        {
            context.Dispose();
        }
    }

    public interface IDocumentRepository : IDisposable
    {
        IQueryable<Document> All { get; }
        IQueryable<Document> AllIncluding(params Expression<Func<Document, object>>[] includeProperties);
        Document Find(int id);
        void InsertOrUpdate(Document document);
        void Delete(int id);
        void Save();
    }
}