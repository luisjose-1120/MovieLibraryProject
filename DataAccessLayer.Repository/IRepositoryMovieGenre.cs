using System;
using System.Collections.Generic;
using System.Text;


using System.Threading.Tasks;
using data = DataAccessLayer.DataObject;

namespace DataAccessLayer.Repository
{
    public interface IRepositoryMovieGenre : IRepository<data.MovieGenre>
    {
        Task<IEnumerable<data.MovieGenre>> GetAllAsync();
        Task<data.MovieGenre> GetOneByIdAsync(long IdMovieGenre);
    }
}
