using System;
using Antra.CRMApp.Core.Contract.Repository;
using Antra.CRMApp.Core.Contract.Service;
using Antra.CRMApp.Core.Model;
using Antra.CRMApp.Core.Entity;

namespace Antra.CRMApp.Infrastructure.Service
{
	public class OrderServiceAsync: IOrderServiceAsync
	{
        private readonly IOrderRepositoryAsync repositoryAsync;
        public OrderServiceAsync(IOrderRepositoryAsync _repositoryAsync)
		{
            repositoryAsync = _repositoryAsync;

        }

        public async Task<int> AddOrderAsync(OrderRequestModel model)
        {
            Order order = new Order();
            order.Id = model.Id;
            order.quantity = model.quantity;
            order.ProductId = model.ProductId;
            order.UnitPrice = model.UnitPrice;
            order.Discount = model.Discount;
            return await repositoryAsync.InsertAsync(order);
        }

        public async Task<int> DeleteOrderAsync(int id)
        {
            return await repositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<OrderResponseModel>> GetAllAsync()
        {
            var collection = await repositoryAsync.GetAllAsync();

            if (collection != null)
            {
                List<OrderResponseModel> result = new List<OrderResponseModel>();
                foreach (var model in collection)
                {
                    OrderResponseModel order = new OrderResponseModel();
                    order.Id = model.Id;
                    order.quantity = model.quantity;
                    order.ProductId = model.ProductId;
                    order.UnitPrice = model.UnitPrice;
                    order.Discount = model.Discount;
                    result.Add(order);
                }
                return result;
            }
            return null;
        }

        public async Task<OrderResponseModel> GetByIdAsync(int id)
        {
            var model = await repositoryAsync.GetByIdAsync(id);
            if (model != null)
            {
                OrderResponseModel order = new OrderResponseModel();
                order.Id = model.Id;
                order.quantity = model.quantity;
                order.ProductId = model.ProductId;
                order.UnitPrice = model.UnitPrice;
                order.Discount = model.Discount;
                return order;
            }
            return null;
        }

        public async Task<OrderRequestModel> GetOrderForEditAsync(int id)
        {
            var model = await repositoryAsync.GetByIdAsync(id);
            if (model != null)
            {
                OrderRequestModel order = new OrderRequestModel();
                order.Id = model.Id;
                order.quantity = model.quantity;
                order.ProductId = model.ProductId;
                order.UnitPrice = model.UnitPrice;
                order.Discount = model.Discount;
                return order;
            }
            return null;
        }

        public async Task<int> UpdateOrderAsync(OrderRequestModel model)
        {
            Order order = new Order();
            order.Id = model.Id;
            order.quantity = model.quantity;
            order.ProductId = model.ProductId;
            order.UnitPrice = model.UnitPrice;
            order.Discount = model.Discount;

            return await repositoryAsync.UpdateAsync(order);
        }
    }
}

