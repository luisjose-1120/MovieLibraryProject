using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataObject.Interfaces
{
    public interface ICRUD<T>
    {
        void Insert(T t);
        void Update(T t);
        void Delete(T t);
        IEnumerable<T> GetAll();
        T GetOneById(long id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetOneByIdAsync(long id);
    }
}
