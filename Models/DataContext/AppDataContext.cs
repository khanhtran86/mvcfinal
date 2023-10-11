using System;
using Microsoft.Extensions.Caching.Distributed;

namespace mvcprojectfinal.Models.DataContext
{
	public class AppDataContext:DapperDbContext
	{
		public AppDataContext(String connectionString):base(connectionString)
		{
		}
	}
}

