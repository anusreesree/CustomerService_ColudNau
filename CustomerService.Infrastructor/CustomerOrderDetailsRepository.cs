using CustomerService.Application;
using CustomerService.Domain;
using Dapper;
using System.Data;

namespace CustomerService.Infrastructor
{
    public class CustomerOrderDetailsRepository: ICustomerOrderDetailsRepository
    {
        private readonly DapperContext _dapperContext;
        public CustomerOrderDetailsRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<CustomerOrder> GetCustomerOrderDetails(string userEmailId, string customerId)
        {

            var query = @"
                        SELECT TOP 1 c.FirstName, c.LastName,o.ORDERID As OrderNumber, o.OrderDate,c.HOUSENO +','+c.STREET +','+c.TOWN,+','+c.POSTCODE AS DeliveryAddres,
                        ot.PRICE AS PriceEach, p.PRODUCTNAME AS Product,ot.QUANTITY,o.DELIVERYEXPECTED
                        FROM CUSTOMERS c 
                        INNER JOIN ORDERS o ON c.CUSTOMERID = o.CUSTOMERID 
                        INNER JOIN ORDERITEMS ot ON o.ORDERID = ot.ORDERID
                        INNER JOINS PROUDUCTS p ON ot.PRODUCTID = p.PRODUCTID
                        WHERE c.CUSTOMERID = @customerId AND c.EMAILID = @userEmailId";
            var parameters = new DynamicParameters();
            parameters.Add("customerId", customerId, DbType.String);
            parameters.Add("userEmailId", userEmailId, DbType.String);
            try
            {

                using (var connection = _dapperContext.CreateConnection())
                {
                    var customerOrderDetails = await connection.QueryFirstAsync<CustomerOrder>(query, parameters);
                    return customerOrderDetails;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
