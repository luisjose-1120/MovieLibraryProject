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
    public class Actor : ICRUD<data.Actor>
    {
        private dal.Actor _dal;
        public Actor(BibliotecaPeliculasContext dbContext)
        {
            _dal = new dal.Actor(dbContext);
        }
        public void Delete(data.Actor t)
        {
            _dal.Delete(t);
        }

        public IEnumerable<data.Actor> GetAll()
        {
            return _dal.GetAll();
        }

        public Task<IEnumerable<data.Actor>> GetAllAsync()
        {
            return _dal.GetAllAsync();
        }

        public data.Actor GetOneById(long id)
        {
            return _dal.GetOneById(id);
        }

        public Task<data.Actor> GetOneByIdAsync(long id)
        {
            return _dal.GetOneByIdAsync(id);
        }

        public void Insert(data.Actor t)
        {
            _dal.Insert(t);
        }

        public void Update(data.Actor t)
        {
            _dal.Update(t);
        }
    }
}
