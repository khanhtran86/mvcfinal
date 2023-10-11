using System;
using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;

namespace mvcprojectfinal.Models.DataContext
{
	public class DapperDbContext
	{
		protected string ConnectionString { get; set; }

		public DapperDbContext(string connectionString)
		{
			if (String.IsNullOrEmpty(connectionString))
				throw new ArgumentException("Connection can't be null or empty");
			this.ConnectionString = connectionString;
		}

		public IDbConnection connection => new SqlConnection(ConnectionString);

		public IEnumerable<T> Exec<T>(string storeProcedure, dynamic parameterObject = null)
		{
			if (String.IsNullOrEmpty(storeProcedure))
				throw new ArgumentException("Executed Store Procedure can't be null or empty");

			var paraObj = (object)parameterObject;
			return connection.Query<T>(storeProcedure, param: paraObj, commandType: CommandType.StoredProcedure);
		}

		public T ExecSingle<T>(String storeProcedure, dynamic parameterObject = null)
		{
			if(String.IsNullOrEmpty(storeProcedure))
                throw new ArgumentException("Executed Store Procedure can't be null or empty");

            var paraObj = (object)parameterObject;
            return connection.QuerySingleOrDefault<T>(storeProcedure, param: paraObj, commandType: CommandType.StoredProcedure);
        }

		public int ExecNonQuery(String storeProcedure, dynamic parameterObject=null)
		{
			if(String.IsNullOrEmpty(storeProcedure))
                throw new ArgumentException("Executed Store Procedure can't be null or empty");

            var paraObj = (object)parameterObject;
            return connection.Execute(storeProcedure, param: paraObj, commandType: CommandType.StoredProcedure);
        }
	}
}

