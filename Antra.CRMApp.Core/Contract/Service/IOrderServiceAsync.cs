using System;
using Antra.CRMApp.Core.Model;

namespace Antra.CRMApp.Core.Contract.Service
{
	public interface IOrderServiceAsync
	{
       
        Task<IEnumerable<OrderResponseModel>> GetAllAsync();
        Task<int> AddOrderAsync(OrderRequestModel model);
        Task<OrderResponseModel> GetByIdAsync(int id);
        Task<OrderRequestModel> GetOrderForEditAsync(int id);
        Task<int> UpdateOrderAsync(OrderRequestModel model);
        Task<int> DeleteOrderAsync(int id);
    }
}

