using JanOneToMany.Data;
using JanOneToMany.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JanOneToMany.Repo
{
    public class GenericRepo: IGenericRepo
    {
        private ApplicationDbContext _db;
        public IQueryable<T> Query<T>() where T : class
        {
            return _db.Set<T>().AsQueryable();
        }
        public void Add<T>(T entityToCreate) where T : class
        {
            _db.Set<T>().Add(entityToCreate);
            _db.SaveChanges();
        }
        public void Update<T>(T entityToUpdate) where T : class
        {
            _db.Set<T>().Update(entityToUpdate);
            _db.SaveChanges();
        }
        public void Delete<T>(T entityToDelete) where T : class
        {
            _db.Set<T>().Remove(entityToDelete);
            _db.SaveChanges();
        }
        public IQueryable<T> SqlQuery<T>(string sql, params object[] parameters) where T : class
        {
            return _db.Set<T>().FromSql(sql, parameters);
        }
        public void Dispose()
        {
            _db.Dispose();
        }
        public GenericRepo(ApplicationDbContext db)
        {
            _db = db;
        }
    }
}
