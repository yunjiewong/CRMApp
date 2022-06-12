using System;
using Antra.CRMApp.Core.Model;

namespace Antra.CRMApp.Core.Contract.Service
{
	public interface ICustomerServiceAsync
	{
      
        Task<IEnumerable<CustomerResponseModel>> GetAllAsync();
        Task<int> AddCustomerAsync(CustomerRequestModel model);
        Task<CustomerResponseModel> GetByIdAsync(int id);
        Task<CustomerRequestModel> GetCustomerForEditAsync(int id);
        Task<int> UpdateCustomersync(CustomerRequestModel model);
        Task<int> DeleteCustomerAsync(int id);
    }
}

