using DataLayer.Entities;
using DataLayer.Interfaces;
using System;

namespace DataLayer.EF
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext db;
        private IRepository<User> phoneRepository;
        private IRepository<Account> orderRepository;

        public EFUnitOfWork(string connectionString)
        {
            db = new ApplicationContext(connectionString);
        }
        public IRepository<User> Users
        {
            get
            {
                if (phoneRepository == null)
                    phoneRepository = new UserRepository(db);
                return phoneRepository;
            }
        }

        public IRepository<Account> Accounts
        {
            get
            {
                if (orderRepository == null)
                    orderRepository = new AccountRepository(db);
                return orderRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
