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
    public class Director : ICRUD<data.Director>
    {
        private Repository<data.Director> repo;
        public Director(BibliotecaPeliculasContext dbContext)
        {
            repo = new Repository<data.Director>(dbContext);
        }
        public void Delete(data.Director t)
        {
            repo.Delete(t);
            repo.Commit();
        }

        public IEnumerable<data.Director> GetAll()
        {
            return repo.GetAll();
        }

        public Task<IEnumerable<data.Director>> GetAllAsync()
        {
            return null;
        }

        public data.Director GetOneById(long id)
        {
            return repo.GetOneByID(id);
        }



        public Task<data.Director> GetOneByIdAsync(long id)
        {
            return null;
        }



        public void Insert(data.Director t)
        {
            repo.Insert(t);
            repo.Commit();
        }

        public void Update(data.Director t)
        {
            repo.Update(t);
            repo.Commit();
        }

    }
}
