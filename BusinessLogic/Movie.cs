using System;
using System.Collections.Generic;
using System.Text;

using data = DataAccessLayer.DataObject;
using dal = DataAccessLayer;
using DataAccessLayer.DataObject.Interfaces;
using DataAccessLayer.Repository;
using DataAccessLayer.EntityFramework;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Movie : ICRUD<data.Movie>
    {
        private dal.Movie _dal;
        public Movie(BibliotecaPeliculasContext dbContext)
        {
            _dal = new dal.Movie(dbContext);
        }
        public void Delete(data.Movie t)
        {
            _dal.Delete(t);
        }

        public IEnumerable<data.Movie> GetAll()
        {
            return null;
        }

        public Task<IEnumerable<data.Movie>> GetAllAsync()
        {
            return _dal.GetAllAsync();
        }

        public data.Movie GetOneById(long id)
        {
            return _dal.GetOneById(id);
        }

        public Task<data.Movie> GetOneByIdAsync(long id)
        {
            return _dal.GetOneByIdAsync(id);
        }

        public void Insert(data.Movie t)
        {
            _dal.Insert(t);
        }

        public void Update(data.Movie t)
        {
            _dal.Update(t);
        }
    }
}
