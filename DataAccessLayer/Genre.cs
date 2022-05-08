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
    public class Genre : ICRUD<data.Genre>
    {
        private Repository<data.Genre> repo;
        public Genre(BibliotecaPeliculasContext dbContext)
        {
            repo = new Repository<data.Genre>(dbContext);
        }
        public void Delete(data.Genre t)
        {
            repo.Delete(t);
            repo.Commit();
        }

        public IEnumerable<data.Genre> GetAll()
        {
            return repo.GetAll();
        }

        public Task<IEnumerable<data.Genre>> GetAllAsync()
        {
            return null;
        }

        public data.Genre GetOneById(long id)
        {
            return repo.GetOneByID(id);
        }



        public Task<data.Genre> GetOneByIdAsync(long id)
        {
            return null;
        }



        public void Insert(data.Genre t)
        {
            repo.Insert(t);
            repo.Commit();
        }

        public void Update(data.Genre t)
        {
            repo.Update(t);
            repo.Commit();
        }
    }
}
