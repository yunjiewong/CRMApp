using System;
using Antra.CRMApp.Core.Model;

namespace Antra.CRMApp.Core.Contract.Service
{
	public interface ICategoryServiceAsync
	{
        Task<IEnumerable<CategoryModel>> GetAllAsync();
        Task<int> AddCatogoryAsync(CategoryModel employee);
        Task<CategoryModel> GetByIdAsync(int id);
        Task<int> UpdateAsync(CategoryModel employee);
        Task<int> DeleteAsync(int id);
    }
}

