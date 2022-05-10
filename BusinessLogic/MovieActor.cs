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
    public class MovieActor : ICRUD<data.MovieActor>
    {
        private dal.MovieActor _dal;
        public MovieActor(BibliotecaPeliculasContext dbContext)
        {
            _dal = new dal.MovieActor(dbContext);
        }
        public void Delete(data.MovieActor t)
        {
            _dal.Delete(t);
        }

        public IEnumerable<data.MovieActor> GetAll()
        {
            return null;
        }

        public Task<IEnumerable<data.MovieActor>> GetAllAsync()
        {
            return _dal.GetAllAsync();
        }

        public data.MovieActor GetOneById(long id)
        {
            return _dal.GetOneById(id);
        }

        public Task<data.MovieActor> GetOneByIdAsync(long id)
        {
            return _dal.GetOneByIdAsync(id);
        }

        public void Insert(data.MovieActor t)
        {
            _dal.Insert(t);
        }

        public void Update(data.MovieActor t)
        {
            _dal.Update(t);
        }
    }
}
