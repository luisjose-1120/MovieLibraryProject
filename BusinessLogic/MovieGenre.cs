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
    public class MovieGenre : ICRUD<data.MovieGenre>
    {
        private dal.MovieGenre _dal;
        public MovieGenre(BibliotecaPeliculasContext dbContext)
        {
            _dal = new dal.MovieGenre(dbContext);
        }
        public void Delete(data.MovieGenre t)
        {
            _dal.Delete(t);
        }

        public IEnumerable<data.MovieGenre> GetAll()
        {
            return null;
        }

        public Task<IEnumerable<data.MovieGenre>> GetAllAsync()
        {
            return _dal.GetAllAsync();
        }

        public data.MovieGenre GetOneById(long id)
        {
            return _dal.GetOneById(id);
        }

        public Task<data.MovieGenre> GetOneByIdAsync(long id)
        {
            return _dal.GetOneByIdAsync(id);
        }

        public void Insert(data.MovieGenre t)
        {
            _dal.Insert(t);
        }

        public void Update(data.MovieGenre t)
        {
            _dal.Update(t);
        }
    }
}
