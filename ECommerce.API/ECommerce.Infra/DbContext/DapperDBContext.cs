using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;
using System.Data.Common;
using Microsoft.Extensions.Configuration;

namespace ECommerce.Infra.DbContext;

public class DapperDBContext
{
    private readonly IConfiguration configuration;
    private readonly IDbConnection connection;

    public DapperDBContext(IConfiguration configuration)
    {
        this.configuration = configuration;
        string? connStr = configuration.GetConnectionString("PostgresConnection");

        //create new npgsqlconn

        connection = new NpgsqlConnection(connStr);
    }

    public IDbConnection Connection => connection;
}
