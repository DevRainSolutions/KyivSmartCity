using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using DevRainSolutions.KyivSmartCity.New.Models;


namespace DevRainSolutions.KyivSmartCity.New.Areas.Admin.Models
{ 
    public class TeamMemberRepository : ITeamMemberRepository
    {
        KyivSmartCityNewContext context = new KyivSmartCityNewContext();

        public IQueryable<TeamMember> All
        {
            get { return context.TeamMembers; }
        }

        public IQueryable<TeamMember> AllIncluding(params Expression<Func<TeamMember, object>>[] includeProperties)
        {
            IQueryable<TeamMember> query = context.TeamMembers;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public TeamMember Find(int id)
        {
            return context.TeamMembers.Find(id);
        }

        public void InsertOrUpdate(TeamMember teammember)
        {
            if (teammember.Id == default(int)) {
                // New entity
                context.TeamMembers.Add(teammember);
            } else {
                // Existing entity
                context.Entry(teammember).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var teammember = context.TeamMembers.Find(id);
            context.TeamMembers.Remove(teammember);
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

    public interface ITeamMemberRepository : IDisposable
    {
        IQueryable<TeamMember> All { get; }
        IQueryable<TeamMember> AllIncluding(params Expression<Func<TeamMember, object>>[] includeProperties);
        TeamMember Find(int id);
        void InsertOrUpdate(TeamMember teammember);
        void Delete(int id);
        void Save();
    }
}