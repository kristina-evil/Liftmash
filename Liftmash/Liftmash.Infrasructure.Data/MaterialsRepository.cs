using Liftmash.Domain.Abstaractions.Repositories;
using Liftmash.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Liftmash.Infrasructure.Data
{
    public class MaterialsRepository : IMaterialsRepository
    {
        private readonly DataContext dataContext;

        public MaterialsRepository(DataContext dataContext)
        {
            this.dataContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
        }

        public async Task<IList<Materials>> GetAll()
        {
            return await this.dataContext.Materials.ToListAsync();
        }

        public async Task<Materials> GetById(long id)
        {
            return await this.dataContext.Materials.FindAsync(id);
        }

        public async Task<IList<Materials>> GetByCriteria(SearchEntity material)
        {
            return await this.dataContext.Materials.Where(b =>
                ((string.IsNullOrEmpty(material.Name) && string.IsNullOrEmpty(material.Article) && string.IsNullOrEmpty(material.Code)) ||
                 (!string.IsNullOrEmpty(material.Name) && string.IsNullOrEmpty(material.Article) && string.IsNullOrEmpty(material.Code)) ||
                 (string.IsNullOrEmpty(material.Name) && !string.IsNullOrEmpty(material.Article) && string.IsNullOrEmpty(material.Code)) ||
                 (string.IsNullOrEmpty(material.Name) && string.IsNullOrEmpty(material.Article) && !string.IsNullOrEmpty(material.Code))))
                 .ToListAsync();
        }

        public async Task Add(Materials materials)
        {
            this.dataContext.Materials.Add(materials);
            await this.dataContext.SaveChangesAsync();
        }

        public async Task Delete(long id)
        {
            this.dataContext.Materials.Remove(this.dataContext.Materials.Find(id));
            await this.dataContext.SaveChangesAsync();
        }

        public async Task Update(Materials materials)
        {
            await Task.Run(() => dataContext.Materials.Attach(materials));

            dataContext.Entry(materials).State = EntityState.Modified;

            await dataContext.SaveChangesAsync();
        }
    }
}

