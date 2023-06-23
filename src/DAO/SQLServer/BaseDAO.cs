using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAO.SQLServer
{
    public class BaseDAO
    {
        private readonly string _connectionString;
        public BaseDAO(string connectionString)
        {
            _connectionString = connectionString;
        }
        //protected string ConnectionString => @"Server=.\SQLEXPRESS;Integrated Security=true;Initial Catalog= curso_hml;";
        protected SqlConnection Connection => new SqlConnection(_connectionString);
    }
}