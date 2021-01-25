using DataLayer.Entities;
using DataLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.EF
{
    public class UserRepository : IRepository<User>
    {
        private readonly ApplicationContext db;

        public UserRepository(ApplicationContext db)
        {
            this.db = db;
        }

        public void Create(User user)
        {
            db.Users.Add(user);
        }

        public void Delete(int id)
        {
            var userToRemove = db.Users.Find(id);

            if(userToRemove != null)
            {
                db.Users.Remove(userToRemove);
            }
        }

        public User Get(int id)
        {
            return db.Users.Find(id);
        }

        public IEnumerable<User> GetAll()
        {
            return db.Users;
        }

        public void Update(User user)
        {
            db.Entry(user).State = EntityState.Modified;
        }
    }
}
