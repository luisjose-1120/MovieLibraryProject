using System;
using System.Collections.Generic;
using System.Text;
using data = DataAccessLayer.DataObject;
using dal = DataAccessLayer;
using DataAccessLayer.EntityFramework;
using System.Threading.Tasks;
using DataAccessLayer.DataObject.Interfaces;

namespace BusinessLogic
{
    public class Genre : ICRUD<data.Genre>
    {
        private dal.Genre _dal;
        public Genre(BibliotecaPeliculasContext dbContext)
        {
            _dal = new dal.Genre(dbContext);
        }
        public void Delete(data.Genre t)
        {
            _dal.Delete(t);
        }

        public IEnumerable<data.Genre> GetAll()
        {
            return _dal.GetAll();
        }

        public Task<IEnumerable<data.Genre>> GetAllAsync()
        {
            return _dal.GetAllAsync();
        }

        public data.Genre GetOneById(long id)
        {
            return _dal.GetOneById(id);
        }

        public Task<data.Genre> GetOneByIdAsync(long id)
        {
            return _dal.GetOneByIdAsync(id);
        }

        public void Insert(data.Genre t)
        {
            _dal.Insert(t);
        }

        public void Update(data.Genre t)
        {
            _dal.Update(t);
        }
    }
}
