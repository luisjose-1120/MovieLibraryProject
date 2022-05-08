using System;
using System.Collections.Generic;
using System.Text;

using data = DataAccessLayer.DataObject;
using dal = DataAccessLayer;
using DataAccessLayer.EntityFramework;
using System.Threading.Tasks;
using DataAccessLayer.DataObject.Interfaces;

namespace DataAccessLayer
{
    public class Production : ICRUD<data.Production>
    {
        private dal.Production _dal;
        public Production(BibliotecaPeliculasContext dbContext)
        {
            _dal = new dal.Production(dbContext);
        }
        public void Delete(data.Production t)
        {
            _dal.Delete(t);
        }

        public IEnumerable<data.Production> GetAll()
        {
            return _dal.GetAll();
        }

        public Task<IEnumerable<data.Production>> GetAllAsync()
        {
            return _dal.GetAllAsync();
        }

        public data.Production GetOneById(long id)
        {
            return _dal.GetOneById(id);
        }

        public Task<data.Production> GetOneByIdAsync(long id)
        {
            return _dal.GetOneByIdAsync(id);
        }

        public void Insert(data.Production t)
        {
            _dal.Insert(t);
        }

        public void Update(data.Production t)
        {
            _dal.Update(t);
        }
    }
}
