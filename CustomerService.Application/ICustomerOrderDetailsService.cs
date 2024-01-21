using CustomerService.Domain;

namespace CustomerService.Application
{
    public interface ICustomerOrderDetailsService
    {
        Task<CustomerOrder> GetCustomerOrderDetails(string userEmailId, string customerId);
    }
}
