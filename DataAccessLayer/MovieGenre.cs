using System;
using System.Collections.Generic;
using System.Text;

using data = DataAccessLayer.DataObject;
using DataAccessLayer.DataObject.Interfaces;
using DataAccessLayer.Repository;
using DataAccessLayer.EntityFramework;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class MovieGenre : ICRUD<data.MovieGenre>
    {
        private RepositoryMovieGenre repo;
        public MovieGenre(BibliotecaPeliculasContext dbContext)
        {
            repo = new RepositoryMovieGenre(dbContext);
        }
        public void Delete(data.MovieGenre t)
        {
            repo.Delete(t);
            repo.Commit();
        }

        public IEnumerable<data.MovieGenre> GetAll()
        {
            return repo.GetAll();
        }

        public Task<IEnumerable<data.MovieGenre>> GetAllAsync()
        {
            return repo.GetAllAsync();
        }

        public data.MovieGenre GetOneById(long id)
        {
            return repo.GetOneByID(id);
        }


        public Task<data.MovieGenre> GetOneByIdAsync(long CompraId)
        {
            return repo.GetOneByIdAsync(CompraId);
        }


        public void Insert(data.MovieGenre t)
        {
            repo.Insert(t);
            repo.Commit();
        }

        public void Update(data.MovieGenre t)
        {
            repo.Update(t);
            repo.Commit();
        }

    }
}
