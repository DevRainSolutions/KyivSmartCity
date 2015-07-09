using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using DevRainSolutions.KyivSmartCity.New.Models;

namespace DevRainSolutions.KyivSmartCity.New.Areas.Admin.Models
{ 
    public class VolunteerRepository : IVolunteerRepository
    {
        KyivSmartCityNewContext context = new KyivSmartCityNewContext();

        public IQueryable<Volunteer> All
        {
            get { return context.Volunteers; }
        }

        public IQueryable<Volunteer> AllIncluding(params Expression<Func<Volunteer, object>>[] includeProperties)
        {
            IQueryable<Volunteer> query = context.Volunteers;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Volunteer Find(int id)
        {
            return context.Volunteers.Find(id);
        }

        public void InsertOrUpdate(Volunteer volunteer)
        {
            if (volunteer.Id == default(int)) {
                // New entity
                context.Volunteers.Add(volunteer);
            } else {
                // Existing entity
                context.Entry(volunteer).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var volunteer = context.Volunteers.Find(id);
            context.Volunteers.Remove(volunteer);
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

    public interface IVolunteerRepository : IDisposable
    {
        IQueryable<Volunteer> All { get; }
        IQueryable<Volunteer> AllIncluding(params Expression<Func<Volunteer, object>>[] includeProperties);
        Volunteer Find(int id);
        void InsertOrUpdate(Volunteer volunteer);
        void Delete(int id);
        void Save();
    }
}