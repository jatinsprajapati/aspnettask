using Pinewood.DMS.API.DAL;
using Dapper;
using Pinewood.DMS.API.DTO;
using System.Data;
using Pinewood.DMS.API.DTO.Response;

namespace Pinewood.DMS.API.Repository
{
    public class CustomerRepository : DapperContext, ICustomerRepository
    {
        public CustomerRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<int> CreateCustomerAsync(CreateCustomerRequest request)
        {
            var insertCustomer = "INSERT INTO Customer" +
                " (FirstName,LastName,Email,Mobile,Gender,Address1,Address2,City,State,PostCode,Country,CustomerStatus)" +
                " VALUES (@FirstName,@LastName,@Email,@Mobile,@Gender,@Address1,@Address2,@City,@State,@PostCode,@Country,@CustomerStatus);SELECT SCOPE_IDENTITY(); ";
            var parameters = new DynamicParameters();
            parameters.Add("FirstName", request.FirstName, DbType.String);
            parameters.Add("LastName", request.LastName, DbType.String);
            parameters.Add("Email", request.Email, DbType.String);
            parameters.Add("Mobile", request.Mobile, DbType.String);
            parameters.Add("Gender", request.Gender, DbType.String);
            parameters.Add("Address1", request.Address1, DbType.String);
            parameters.Add("Address2", request.Address2, DbType.String);
            parameters.Add("City", request.City, DbType.String);
            parameters.Add("State", request.State, DbType.String);
            parameters.Add("PostCode", request.PostCode, DbType.String);
            parameters.Add("Country", request.Country, DbType.String);
            parameters.Add("CustomerStatus", request.CustomerStatus, DbType.Int32);


            using (var connection = CreateConnection())
            {
                var customerId = await connection.ExecuteScalarAsync(insertCustomer, parameters);
                return Convert.ToInt32(customerId);
            }
        }

        public async Task<List<GetCustomerListResponse>> GetCustomerListAsync()
        {
            var customerList = "select * from Customer Where  IsDeleted=0";
            using (var connections = CreateConnection())
            {
                return (await connections.QueryAsync<GetCustomerListResponse>(customerList)).ToList();
            }
        }

        public async Task<GetCustomerListResponse> GetCustomerById(int customerId)
        {
            var customerData = "select * from Customer Where CustomerId = @CustomerId AND IsDeleted=0";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", customerId, DbType.Int32);
            using (var connections = CreateConnection())
            {               
                return await connections.QuerySingleOrDefaultAsync<GetCustomerListResponse>(customerData, parameters);
            }
        }
        public async Task<int> UpdateCustomerAsync(UpdateCustomerRequest request)
        {
            var updateCustomer = "Update Customer SET FirstName=@FirstName,LastName=@LastName,Email=@Email,Mobile=@Mobile," +
                "Gender=@Gender,Address1=@Address1,Address2=@Address2,City=@City,State=@State,PostCode=@PostCode,Country=@Country," +
                "CustomerStatus=@CustomerStatus,ModifiedOn=@ModifiedOn WHERE CustomerId=@CustomerId";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", request.CustomerId, DbType.Int32);
            parameters.Add("FirstName", request.FirstName, DbType.String);
            parameters.Add("LastName", request.LastName, DbType.String);
            parameters.Add("Email", request.Email, DbType.String);
            parameters.Add("Mobile", request.Mobile, DbType.String);
            parameters.Add("Gender", request.Gender, DbType.String);
            parameters.Add("Address1", request.Address1, DbType.String);
            parameters.Add("Address2", request.Address2, DbType.String);
            parameters.Add("City", request.City, DbType.String);
            parameters.Add("State", request.State, DbType.String);
            parameters.Add("PostCode", request.PostCode, DbType.String);
            parameters.Add("Country", request.Country, DbType.String);
            parameters.Add("CustomerStatus", request.CustomerStatus, DbType.Int32);
            parameters.Add("ModifiedOn", DateTime.UtcNow, DbType.DateTime);
            using (var connection = CreateConnection())
            {
                return (await connection.ExecuteAsync(updateCustomer, parameters));
            }
        }

        public async Task<int> DeleteCustomerAsync(IdDTO request)
        {
            var deleteCustomerWish = "DELETE from Customer WHERE CustomerId=@CustomerId";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", request.Id, DbType.Int32);
            using (var connection = CreateConnection())
            {
                return (await connection.ExecuteAsync(deleteCustomerWish, parameters));
            }
        }
    }
}
