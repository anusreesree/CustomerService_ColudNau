using CustomerService.Domain;

namespace CustomerService.Application
{
    public interface ICustomerOrderDetailsRepository
    {
        Task<CustomerOrder> GetCustomerOrderDetails(string userEmailId, string customerId);
    }
}
