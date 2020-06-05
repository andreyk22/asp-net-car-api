using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using car_api_aspnet_core.Interfaces;
using car_api_aspnet_core.Model;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace car_api_aspnet_core.DataAccess
{
    public class CarDA : ICarDA
    {
        private readonly IConfiguration _configuration;
        public CarDA(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<IEnumerable<ICarResponse>> GetAll()
        {
            var sql = "SELECT * FROM rest.Car C LEFT JOIN rest.Owner O ON C.ownerId = O.Id ORDER BY C.Id";

            using (var connection = new SqlConnection(_configuration.GetConnectionString("restDB")))
            {
                connection.Open();
                var result = await connection.QueryAsync<ICarResponse, Owner, ICarResponse>(sql, (car, owner) => { car.Owner = owner;
                    return car;
                });
                return result;
            }
        }

        public async Task<ICarResponse> Get(int id)
        {
            var sql = "SELECT * FROM rest.Car C LEFT JOIN rest.Owner O ON C.ownerId = O.Id where C.Id = @Id";
           
            using (var connection = new SqlConnection(_configuration.GetConnectionString("restDB")))
            {
                connection.Open();
                var result = await connection.QueryAsync<ICarResponse, Owner, ICarResponse>(sql, (car, owner) => { car.Owner = owner;
                    return car;
                }, new {Id = id});
                return result.FirstOrDefault();
            }
        }
        
        public async Task<ICarResponse> Add(Car car)
        {
            var sql = "INSERT INTO rest.Car (make, model, color, year, price, available, ownerId) Values (@Make, @Model, @Color, @Year, @Price, @Available, @OwnerId); SELECT CAST(scope_identity() AS int);";
           
            using (var connection = new SqlConnection(_configuration.GetConnectionString("restDB")))
            {
                connection.Open();
                var newCarId = await connection.ExecuteScalarAsync(sql, car);
                var newCarObject = await Get((int)newCarId);
                return newCarObject;
            }
        }
    }
}