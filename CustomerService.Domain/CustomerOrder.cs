namespace CustomerService.Domain
{
    public class CustomerOrder
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Order Order { get; set; }

    }
}
