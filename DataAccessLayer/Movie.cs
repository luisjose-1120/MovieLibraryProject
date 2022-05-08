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
    public class Movie : ICRUD<data.Movie>
    {
        private RepositoryMovie repo;
        public Movie(BibliotecaPeliculasContext dbContext)
        {
            repo = new RepositoryMovie(dbContext);
        }
        public void Delete(data.Movie t)
        {
            repo.Delete(t);
            repo.Commit();
        }

        public IEnumerable<data.Movie> GetAll()
        {
            return repo.GetAll();
        }

        public Task<IEnumerable<data.Movie>> GetAllAsync()
        {
            return repo.GetAllAsync();
        }

        public data.Movie GetOneById(long id)
        {
            return repo.GetOneByID(id);
        }


        public Task<data.Movie> GetOneByIdAsync(long CompraId)
        {
            return repo.GetOneByIdAsync(CompraId);
        }


        public void Insert(data.Movie t)
        {
            repo.Insert(t);
            repo.Commit();
        }

        public void Update(data.Movie t)
        {
            repo.Update(t);
            repo.Commit();
        }
    }
}
