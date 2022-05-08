using System;
using System.Collections.Generic;
using System.Text;

using data = DataAccessLayer.DataObject;
using DataAccessLayer.Repository;
using DataAccessLayer.DataObject.Interfaces;
using DataAccessLayer.EntityFramework;
using System.Threading.Tasks;


namespace BusinessLogic
{
    public class Production : ICRUD<data.Production>
    {
        private Repository<data.Production> repo;
        public Production(BibliotecaPeliculasContext dbContext)
        {
            repo = new Repository<data.Production>(dbContext);
        }
        public void Delete(data.Production t)
        {
            repo.Delete(t);
            repo.Commit();
        }

        public IEnumerable<data.Production> GetAll()
        {
            return repo.GetAll();
        }

        public Task<IEnumerable<data.Production>> GetAllAsync()
        {
            return null;
        }

        public data.Production GetOneById(long id)
        {
            return repo.GetOneByID(id);
        }



        public Task<data.Production> GetOneByIdAsync(long id)
        {
            return null;
        }



        public void Insert(data.Production t)
        {
            repo.Insert(t);
            repo.Commit();
        }

        public void Update(data.Production t)
        {
            repo.Update(t);
            repo.Commit();
        }
    }
}
