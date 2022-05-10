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
    public class RepositoryMovieActor : Repository<data.MovieActor>, IRepositoryMovieActor
    {
        public RepositoryMovieActor(BibliotecaPeliculasContext _dbContext) : base(_dbContext)
        {

        }

        public async Task<IEnumerable<MovieActor>> GetAllAsync()
        {
            return await _db.MovieActor
                .Include(m => m.IdActorNavigation)

                .Include(z => z.IdMovieNavigation)
                
                .ToListAsync()
                ;
        }

        public async Task<MovieActor> GetOneByIdAsync(long IdMovieActor)
        {
            return await _db.MovieActor
                 .Include(m => m.IdActorNavigation)

                .Include(z => z.IdMovieNavigation)

                .SingleOrDefaultAsync(m => m.IdMovieActor == IdMovieActor)
                ;
        }


        private BibliotecaPeliculasContext _db
        {
            get { return dbContext as BibliotecaPeliculasContext; }
        }
    }
}
