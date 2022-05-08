using System;
using System.Collections.Generic;
using System.Text;
using data = DataAccessLayer.DataObject;
using DataAccessLayer.Repository;
using DataAccessLayer.DataObject.Interfaces;
using DataAccessLayer.EntityFramework;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Actor : ICRUD<data.Actor>
    {
        private Repository<data.Actor> repo;
        public Actor(BibliotecaPeliculasContext dbContext)
        {
            repo = new Repository<data.Actor>(dbContext);
        }
        public void Delete(data.Actor t)
        {
            repo.Delete(t);
            repo.Commit();
        }

        public IEnumerable<data.Actor> GetAll()
        {
            return repo.GetAll();
        }

        public Task<IEnumerable<data.Actor>> GetAllAsync()
        {
            return null;
        }

        public data.Actor GetOneById(long id)
        {
            return repo.GetOneByID(id);
        }



        public Task<data.Actor> GetOneByIdAsync(long id)
        {
            return null;
        }



        public void Insert(data.Actor t)
        {
            repo.Insert(t);
            repo.Commit();
        }

        public void Update(data.Actor t)
        {
            repo.Update(t);
            repo.Commit();
        }
    }
}
