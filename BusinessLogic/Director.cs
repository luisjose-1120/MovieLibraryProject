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
    public class Director : ICRUD<data.Director>
    {
        private dal.Director _dal;
        public Director(BibliotecaPeliculasContext dbContext)
        {
            _dal = new dal.Director(dbContext);
        }
        public void Delete(data.Director t)
        {
            _dal.Delete(t);
        }

        public IEnumerable<data.Director> GetAll()
        {
            return _dal.GetAll();
        }

        public Task<IEnumerable<data.Director>> GetAllAsync()
        {
            return _dal.GetAllAsync();
        }

        public data.Director GetOneById(long id)
        {
            return _dal.GetOneById(id);
        }

        public Task<data.Director> GetOneByIdAsync(long id)
        {
            return _dal.GetOneByIdAsync(id);
        }

        public void Insert(data.Director t)
        {
            _dal.Insert(t);
        }

        public void Update(data.Director t)
        {
            _dal.Update(t);
        }
    }
}
