
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using DevRainSolutions.KyivSmartCity.New.Models;

namespace DevRainSolutions.KyivSmartCity.New.Areas.Admin.Models
{ 
    public class NewsItemRepository : INewsItemRepository
    {
        KyivSmartCityNewContext context = new KyivSmartCityNewContext();

        public IQueryable<NewsItem> All
        {
            get { return context.NewsItems; }
        }

        public IQueryable<NewsItem> AllIncluding(params Expression<Func<NewsItem, object>>[] includeProperties)
        {
            IQueryable<NewsItem> query = context.NewsItems;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public NewsItem Find(int id)
        {
            return context.NewsItems.Find(id);
        }

        public void InsertOrUpdate(NewsItem newsitem)
        {
            if (newsitem.Id == default(int)) {
                // New entity
                context.NewsItems.Add(newsitem);
            } else {
                // Existing entity
                context.Entry(newsitem).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var newsitem = context.NewsItems.Find(id);
            context.NewsItems.Remove(newsitem);
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

    public interface INewsItemRepository : IDisposable
    {
        IQueryable<NewsItem> All { get; }
        IQueryable<NewsItem> AllIncluding(params Expression<Func<NewsItem, object>>[] includeProperties);
        NewsItem Find(int id);
        void InsertOrUpdate(NewsItem newsitem);
        void Delete(int id);
        void Save();
    }
}