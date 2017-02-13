using System.Linq;

namespace JanOneToMany.Interfaces
{
    public interface IGenericRepo
    {
        void Add<T>(T entityToCreate) where T : class;
        void Delete<T>(T entityToDelete) where T : class;
        void Dispose();
        IQueryable<T> Query<T>() where T : class;
        IQueryable<T> SqlQuery<T>(string sql, params object[] parameters) where T : class;
        void Update<T>(T entityToUpdate) where T : class;
    }
}