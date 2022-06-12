using System;
using Antra.CRMApp.Core.Contract.Repository;
using Antra.CRMApp.Core.Contract.Service;
using Antra.CRMApp.Core.Entity;
using Antra.CRMApp.Core.Model;
using Antra.CRMApp.Infrastructure.Data;

namespace Antra.CRMApp.Infrastructure.Service
{
	public class CustomerServiceAsync: ICustomerServiceAsync
	{
        private readonly ICustomerRepositoryAsync repositoryAsync;
        public CustomerServiceAsync(ICustomerRepositoryAsync _repositoryAsync)
		{
            repositoryAsync = _repositoryAsync;

        }

        public async Task<int> AddCustomerAsync(CustomerRequestModel model)
        {
            Customer customer = new Customer();
            customer.Id = model.Id;
            customer.Name = model.Name;
            customer.Phone = model.Phone;
            customer.PostalCode = model.PostalCode;
            customer.RegionId = model.RegionId;
            customer.Title = model.Title;
            customer.Address = model.Address;
            customer.City = model.City;
            customer.Country = model.Country;

            return await repositoryAsync.InsertAsync(customer);
        }

        public async Task<int> DeleteCustomerAsync(int id)
        {
            return await repositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<CustomerResponseModel>> GetAllAsync()
        {
            var collection = await repositoryAsync.GetAllAsync();

            if (collection != null)
            {
                List<CustomerResponseModel> result = new List<CustomerResponseModel>();
                foreach (var model in collection)
                {
                    CustomerResponseModel customer = new CustomerResponseModel();
                    customer.Id = model.Id;
                    customer.Name = model.Name;
                    customer.Phone = model.Phone;
                    customer.RegionId = model.RegionId;
                    customer.City = model.City;
                    result.Add(customer);
                }
                return result;
            }
            return null;
        }

        public async Task<CustomerResponseModel> GetByIdAsync(int id)
        {
            var model = await repositoryAsync.GetByIdAsync(id);
            if (model != null)
            {
                CustomerResponseModel customer = new CustomerResponseModel();
                customer.Id = model.Id;
                customer.Name = model.Name;
                customer.Phone = model.Phone;
                customer.RegionId = model.RegionId;
                customer.City = model.City;
                return customer;
            }
            return null;
        }

        public async Task<CustomerRequestModel> GetCustomerForEditAsync(int id)
        {
            var model = await repositoryAsync.GetByIdAsync(id);
            if (model != null)
            {
                CustomerRequestModel customer = new CustomerRequestModel();
                customer.Id = model.Id;
                customer.Name = model.Name;
                customer.Phone = model.Phone;
                customer.PostalCode = model.PostalCode;
                customer.RegionId = model.RegionId;
                customer.Title = model.Title;
                customer.Address = model.Address;
                customer.City = model.City;
                customer.Country = model.Country;
                return customer;
            }
            return null;
        }

        public async Task<int> UpdateCustomersync(CustomerRequestModel model)
        {
            Customer customer = new Customer();
            customer.Id = model.Id;
            customer.Name = model.Name;
            customer.Phone = model.Phone;
            customer.PostalCode = model.PostalCode;
            customer.RegionId = model.RegionId;
            customer.Title = model.Title;
            customer.Address = model.Address;
            customer.City = model.City;
            customer.Country = model.Country;
            return await repositoryAsync.UpdateAsync(customer);
        }
    }
}

