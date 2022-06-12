using Antra.CRMApp.Core.Contract.Repository;
using Antra.CRMApp.Core.Contract.Service;
using Antra.CRMApp.Core.Entity;
using Antra.CRMApp.Core.Model;
using System;


namespace Antra.CRMApp.Infrastructure.Service
{
    public class ProductServiceAsync : IProductServiceAsync
    {
        private readonly IProductRepositoryAsync repositoryAsync;
        public ProductServiceAsync(IProductRepositoryAsync _repositoryAsync)
        {
            repositoryAsync = _repositoryAsync;
        }

        public async Task<int> AddProductAsync(ProductRequestModel model)
        {
            Product product = new Product();
            product.Id = model.Id;
            product.Name = model.Name;
            product.QuantityPerUnit = model.QuantityPerUnit;
            product.ReorderLevel = model.ReorderLevel;
            product.SupplierId = model.SupplierId;
            product.CategoryId = model.CategoryId;
            product.Discontinued = model.Discontinued;
            product.UnitPrice = model.UnitPrice;
            product.UnitsInStock = model.UnitsInStock;
            product.UnitsOnOrder = model.UnitsOnOrder;
            return await repositoryAsync.InsertAsync(product);
        }

        public async Task<int> DeleteProductAsync(int id)
        {
            return await repositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<ProductResponseModel>> GetAllAsync()
        {
            var collection = await repositoryAsync.GetAllAsync();

            if (collection != null)
            {
                List<ProductResponseModel> result = new List<ProductResponseModel>();
                foreach (var model in collection)
                {
                    ProductResponseModel product = new ProductResponseModel();
                    product.Id = model.Id;
                    product.Name = model.Name;
                    product.QuantityPerUnit = model.QuantityPerUnit;
                    product.ReorderLevel = model.ReorderLevel;
                    product.SupplierId = model.SupplierId;
                    product.CategoryId = model.CategoryId;
                    product.Discontinued = model.Discontinued;
                    product.UnitPrice = model.UnitPrice;
                    product.UnitsInStock = model.UnitsInStock;
                    product.UnitsOnOrder = model.UnitsOnOrder;
                    result.Add(product);
                }
                return result;
            }
            return null;
        }

        public async Task<ProductResponseModel> GetByIdAsync(int id)
        {
            var model = await repositoryAsync.GetByIdAsync(id);
            if (model != null)
            {
                ProductResponseModel product = new ProductResponseModel();
                product.Id = model.Id;
                product.Name = model.Name;
                product.QuantityPerUnit = model.QuantityPerUnit;
                product.ReorderLevel = model.ReorderLevel;
                product.SupplierId = model.SupplierId;
                product.CategoryId = model.CategoryId;
                product.Discontinued = model.Discontinued;
                product.UnitPrice = model.UnitPrice;
                product.UnitsInStock = model.UnitsInStock;
                product.UnitsOnOrder = model.UnitsOnOrder;
                return product;
            }
            return null;
        }

        public async Task<ProductRequestModel> GetProductForEditAsync(int id)
        {
            var model = await repositoryAsync.GetByIdAsync(id);
            if (model != null)
            {
                ProductRequestModel product = new ProductRequestModel();
                product.Id = model.Id;
                product.Name = model.Name;
                product.QuantityPerUnit = model.QuantityPerUnit;
                product.ReorderLevel = model.ReorderLevel;
                product.SupplierId = model.SupplierId;
                product.CategoryId = model.CategoryId;
                product.Discontinued = model.Discontinued;
                product.UnitPrice = model.UnitPrice;
                product.UnitsInStock = model.UnitsInStock;
                product.UnitsOnOrder = model.UnitsOnOrder;
                return product;
            }
            return null;
        }

        public async Task<int> UpdateProductAsync(ProductRequestModel model)
        {
            Product product = new Product();
            product.Id = model.Id;
            product.Name = model.Name;
            product.QuantityPerUnit = model.QuantityPerUnit;
            product.ReorderLevel = model.ReorderLevel;
            product.SupplierId = model.SupplierId;
            product.CategoryId = model.CategoryId;
            product.Discontinued = model.Discontinued;
            product.UnitPrice = model.UnitPrice;
            product.UnitsInStock = model.UnitsInStock;
            product.UnitsOnOrder = model.UnitsOnOrder;
            return await repositoryAsync.UpdateAsync(product);
        }
    }
}
