using Liftmash.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Liftmash.Domain.Abstaractions.Repositories
{
    public interface IMaterialsRepository
    {
        public Task<IList<Materials>> GetAll();
        public Task<Materials> GetById(long id);
        public Task<IList<Materials>> GetByCriteria(SearchEntity material);
        public Task Add(Materials materials);
        public Task Update(Materials materials);
        public Task Delete(long id);
    }
}
