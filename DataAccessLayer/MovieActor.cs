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
    public class MovieActor : ICRUD<data.MovieActor>
    {
        private RepositoryMovieActor repo;
        public MovieActor(BibliotecaPeliculasContext dbContext)
        {
            repo = new RepositoryMovieActor(dbContext);
        }
        public void Delete(data.MovieActor t)
        {
            repo.Delete(t);
            repo.Commit();
        }

        public IEnumerable<data.MovieActor> GetAll()
        {
            return repo.GetAll();
        }

        public Task<IEnumerable<data.MovieActor>> GetAllAsync()
        {
            return repo.GetAllAsync();
        }

        public data.MovieActor GetOneById(long id)
        {
            return repo.GetOneByID(id);
        }


        public Task<data.MovieActor> GetOneByIdAsync(long CompraId)
        {
            return repo.GetOneByIdAsync(CompraId);
        }


        public void Insert(data.MovieActor t)
        {
            repo.Insert(t);
            repo.Commit();
        }

        public void Update(data.MovieActor t)
        {
            repo.Update(t);
            repo.Commit();
        }

    }
}
