﻿using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.Common;

namespace CustomerService.Infrastructor
{
    public class DapperContext
    {

        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("SqlConnectionString");
        }

        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
