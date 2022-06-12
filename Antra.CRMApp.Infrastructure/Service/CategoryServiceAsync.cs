using System;
using Antra.CRMApp.Core.Contract.Repository;
using Antra.CRMApp.Core.Contract.Service;
using Antra.CRMApp.Core.Entity;
using Antra.CRMApp.Core.Model;

namespace Antra.CRMApp.Infrastructure.Service
{
	public class CategoryServiceAsync: ICategoryServiceAsync
	{
        private ICategoryRepositoryAsync repositoryAsync;
		public CategoryServiceAsync(ICategoryRepositoryAsync _cat)
		{
            repositoryAsync = _cat;
		}

        public async Task<int> AddCatogoryAsync(CategoryModel cat)
        {
            Category category = new Category();
            category.Id = cat.Id;
            category.Name = cat.Name;
            category.Description = cat.Description;
            return await repositoryAsync.InsertAsync(category);
        }

        public async Task<int> DeleteAsync(int id)
        {
             return await repositoryAsync.DeleteAsync(id);
            
        }

        public async Task<IEnumerable<CategoryModel>> GetAllAsync()
        {
            var collection = await repositoryAsync.GetAllAsync();
            if(collection != null)
            {
                List<CategoryModel> models = new List<CategoryModel>();
                foreach(var cat in collection)
                {
                    var category = new CategoryModel();
                    category.Id = cat.Id;
                    category.Name = cat.Name;
                    category.Description = cat.Description;
                    models.Add(category);
                }
                return models;
            }
            return null;
        }

        public async Task<CategoryModel> GetByIdAsync(int id)
        {
            var cat = await repositoryAsync.GetByIdAsync(id);
            if (cat != null)
            {
                CategoryModel category = new CategoryModel();
                category.Id = cat.Id;
                category.Name = cat.Name;
                category.Description = cat.Description;
                return category;
            }
            return null;
           
            
        }

        public async Task<int> UpdateAsync(CategoryModel cat)
        {
            Category category = new Category();
            category.Id = cat.Id;
            category.Name = cat.Name;
            category.Description = cat.Description;
            return await repositoryAsync.UpdateAsync(category);
        }
    }
}

