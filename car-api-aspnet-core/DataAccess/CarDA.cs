using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task<IEnumerable<Car>> GetAll()
        {
            var sql = "SELECT * FROM rest.Car;";

            using (var connection = new SqlConnection(_configuration.GetConnectionString("restDB")))
            {
                connection.Open();
                var result = await connection.QueryAsync<Car>(sql);
                return result;
            }
        }

        public async Task<Car> Get(int id)
        {
            var sql = "SELECT * FROM rest.Car where Id = @Id";
           
            using (var connection = new SqlConnection(_configuration.GetConnectionString("restDB")))
            {
                connection.Open();
                var result = await connection.QueryAsync<Car>(sql, new { Id = id });
                return result.FirstOrDefault();
            }
        }
        
        public async Task<int> Add(Car car)
        {
            var sql = "INSERT INTO rest.Car (make, model, color, year, price, available) Values (@Make, @Model, @Color, @Year, @Price, @Available)";
           
            using (var connection = new SqlConnection(_configuration.GetConnectionString("restDB")))
            {
                connection.Open();
                var addedRows = await connection.ExecuteAsync(sql, car);
                return addedRows;
            }
        }
    }
}