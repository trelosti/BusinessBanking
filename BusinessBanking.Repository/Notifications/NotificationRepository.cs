using BusinessBanking.DAL.DataContexts;
using BusinessBanking.Domain.Entity;
using BusinessBanking.Interface.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessBanking.Repository.Notifications
{
    public class NotificationRepository : IBaseRepository<Notification>
    {
        private readonly DataContext _db;

        public NotificationRepository(DataContext dataContext)
        {
            _db = dataContext;
        }

        public async Task<int> Create(Notification entity)
        {
            await _db.Notifications.AddAsync(entity);
            await _db.SaveChangesAsync();

            return entity.ID;
        }

        public IQueryable<Notification> GetAll()
        {
            return _db.Notifications;
        }

        public async Task<Notification> Update(Notification entity)
        {
            _db.Notifications.Update(entity);
            await _db.SaveChangesAsync();

            return entity;
        }
    }
}
