using System;
using System.Collections.Generic;
using System.Text;

using DataAccessLayer.EntityFramework;
using System.Threading.Tasks;
using data = DataAccessLayer.DataObject;
using DataAccessLayer.DataObject;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repository
{
    public class RepositoryMovie : Repository<data.Movie>, IRepositoryMovie
    {
        public RepositoryMovie(BibliotecaPeliculasContext _dbContext) : base(_dbContext)
        {

        }

        public async Task<IEnumerable<Movie>> GetAllAsync()
        {
            return await _db.Movie
                .Include(m => m.IdDirectorNavigation)

                .Include(z => z.IdProductionNavigation)


                .ToListAsync();
        }

        public async Task<Movie> GetOneByIdAsync(long IdMovie)
        {
            return await _db.Movie
                 .Include(m => m.IdDirectorNavigation)

                .Include(z => z.IdProductionNavigation)

                .SingleOrDefaultAsync(m => m.IdMovie == IdMovie);
        }


        private BibliotecaPeliculasContext _db
        {
            get { return dbContext as BibliotecaPeliculasContext; }
        }
    }
}
