using System;
using System.Collections.Generic;
using System.Text;

using System.Threading.Tasks;
using data = DataAccessLayer.DataObject;

namespace DataAccessLayer.Repository
{
    public interface IRepositoryMovie : IRepository<data.Movie>
    {
        Task<IEnumerable<data.Movie>> GetAllAsync();
        Task<data.Movie> GetOneByIdAsync(long IdRutina);
    }
}
