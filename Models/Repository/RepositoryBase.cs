using System;
namespace mvcprojectfinal.Models.Repository
{
	public class RepositoryBase
	{
		public int RowPerPage = 5;
		public RepositoryBase(IConfiguration appConfig)
		{
			int rowPerPageSettingValue = appConfig.GetValue<int>("ApplicationSettings:RowPerPage");
			if (rowPerPageSettingValue > 0)
				this.RowPerPage = rowPerPageSettingValue;

        }
	}
}

