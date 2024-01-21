using CustomerService.Domain;

namespace CustomerService.Application
{
    public class CustomerOrderDetailsService : ICustomerOrderDetailsService
    {
        private readonly ICustomerOrderDetailsRepository _customerOrderDetailsRepository;
        public CustomerOrderDetailsService(ICustomerOrderDetailsRepository  customerOrderDetailsRepository)
        {
             _customerOrderDetailsRepository = customerOrderDetailsRepository;
        }

        public async Task<CustomerOrder> GetCustomerOrderDetails(string userEmailId, string customerId)
        {
           return await _customerOrderDetailsRepository.GetCustomerOrderDetails(userEmailId, customerId);
        }
    
    }
}
