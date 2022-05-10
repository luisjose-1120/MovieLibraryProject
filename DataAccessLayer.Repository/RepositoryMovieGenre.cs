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
    public class RepositoryMovieGenre : Repository<data.MovieGenre>, IRepositoryMovieGenre
    {
        public RepositoryMovieGenre(BibliotecaPeliculasContext _dbContext) : base(_dbContext)
        {

        }

        public async Task<IEnumerable<MovieGenre>> GetAllAsync()
        {
            return await _db.MovieGenre
                .Include(m => m.IdGenreNavigation)

                .Include(z => z.IdMovieNavigation)

                .ToListAsync()
                ;
        }

        public async Task<MovieGenre> GetOneByIdAsync(long IdMovieGenre)
        {
            return await _db.MovieGenre
                 .Include(m => m.IdGenreNavigation)

                .Include(z => z.IdMovieNavigation)

                .SingleOrDefaultAsync(m => m.IdMovieGenre == IdMovieGenre)
                ;
        }


        private BibliotecaPeliculasContext _db
        {
            get { return dbContext as BibliotecaPeliculasContext; }
        }
    }
}
