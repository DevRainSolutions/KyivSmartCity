
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using DevRainSolutions.KyivSmartCity.New.Models;

namespace DevRainSolutions.KyivSmartCity.New.Areas.Admin.Models
{ 
    public class ExpertRepository : IExpertRepository
    {
        KyivSmartCityNewContext context = new KyivSmartCityNewContext();

        public IQueryable<Expert> All
        {
            get { return context.Experts; }
        }

        public IQueryable<Expert> AllIncluding(params Expression<Func<Expert, object>>[] includeProperties)
        {
            IQueryable<Expert> query = context.Experts;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Expert Find(int id)
        {
            return context.Experts.Find(id);
        }

        public void InsertOrUpdate(Expert expert)
        {
            if (expert.Id == default(int)) {
                // New entity
                context.Experts.Add(expert);
            } else {
                // Existing entity
                context.Entry(expert).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var expert = context.Experts.Find(id);
            context.Experts.Remove(expert);
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

    public interface IExpertRepository : IDisposable
    {
        IQueryable<Expert> All { get; }
        IQueryable<Expert> AllIncluding(params Expression<Func<Expert, object>>[] includeProperties);
        Expert Find(int id);
        void InsertOrUpdate(Expert expert);
        void Delete(int id);
        void Save();
    }
}