using System;
using System.Collections.Generic;
using System.Text;

using System.Threading.Tasks;
using data = DataAccessLayer.DataObject;

namespace DataAccessLayer.Repository
{
    public interface IRepositoryMovieActor : IRepository<data.MovieActor>
    {
        Task<IEnumerable<data.MovieActor>> GetAllAsync();
        Task<data.MovieActor> GetOneByIdAsync(long IdMovieActor);
    }
}
