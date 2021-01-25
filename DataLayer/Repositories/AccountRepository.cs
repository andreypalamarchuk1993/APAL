using DataLayer.Entities;
using DataLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.EF
{
    public class AccountRepository : IRepository<Account>
    {
        private readonly ApplicationContext db;

        public AccountRepository(ApplicationContext db)
        {
            this.db = db;
        }

        public void Create(Account item)
        {
            db.Accounts.Add(item);
        }

        public void Delete(int id)
        {
            var accountToRemove = db.Accounts.Find(id);

            if(accountToRemove != null)
            {
                db.Accounts.Remove(accountToRemove);
            }
        }

        public Account Get(int id)
        {
            return db.Accounts.Find(id);
        }

        public IEnumerable<Account> GetAll()
        {
            return db.Accounts;
        }

        public void Update(Account account)
        {
            db.Entry(account).State = EntityState.Modified;
        }
    }
}
