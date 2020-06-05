using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using car_api_aspnet_core.Interfaces;
using car_api_aspnet_core.Model;
using Dapper;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Configuration;

namespace car_api_aspnet_core.DataAccess
{
    public class OwnerDA : IOwnerDA
    {
        private readonly IConfiguration _configuration;

        public OwnerDA(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IEnumerable<Owner>> GetAll()
        {
            var sql = "SELECT * FROM rest.Owner;";

            using (var connection = new SqlConnection(_configuration.GetConnectionString("restDB")))
            {
                connection.Open();
                var result = await connection.QueryAsync<Owner>(sql);
                return result;
            }
        }

        public async Task<IOwnerResponse> Get(int id)
        {
            var sql = "SELECT * FROM rest.Owner O LEFT JOIN rest.Car C ON O.Id = C.ownerId where O.Id = @Id";
           
            using (var connection = new SqlConnection(_configuration.GetConnectionString("restDB")))
            {
                connection.Open();
                var carsToBeAdded = new List<Car>();
                var result = await connection.QueryAsync<IOwnerResponse, Car, IOwnerResponse>(sql, (owner, cars) => {
                    if (cars != null)
                    {
                        carsToBeAdded.Add(cars);    
                    }
                    return owner;
                }, new {Id = id}, splitOn: "Id");
                var response = result.FirstOrDefault();
                if (response != null)
                {
                    response.Cars = carsToBeAdded;    
                }
                return response;
            }
        }
        
        public async Task<IOwnerResponse> Add(Owner owner)
        {
            var sql = "INSERT INTO rest.Owner (firstName, lastName, age, address) Values (@FirstName, @LastName, @Age, @Address); SELECT CAST(scope_identity() AS int);";
           
            using (var connection = new SqlConnection(_configuration.GetConnectionString("restDB")))
            {
                connection.Open();
                var newOwnerId = await connection.ExecuteScalarAsync(sql, owner);
                var newOwnerObject = await Get((int)newOwnerId);
                return newOwnerObject;
            }
        }
    }
}