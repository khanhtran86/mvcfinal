using System;
using mvcprojectfinal.Models.DataContext;

namespace mvcprojectfinal.Models.Repository
{
	public interface IProductRepository
	{
		public IEnumerable<Product> GetProducts(int page = 1);

		public int GetTotalProductPage();

		public Product GetProduct(int Id);
	}

    public class ProductRepository:RepositoryBase, IProductRepository
    {
		private AppDataContext dbContext;
		
		public ProductRepository(AppDataContext _dbContext, IConfiguration configuration):base(configuration)
		{
			this.dbContext = _dbContext;
		}

		public IEnumerable<Product> GetProducts(int page = 1)
		{
			return this.dbContext.Exec<Product>("spSelectProducts", new { page = page, rowPerPage = this.RowPerPage });
		}

        public int GetTotalProductPage()
		{
			int totalProducts = this.dbContext.ExecSingle<int>("spSelectProductsCount");

			return (int)Math.Ceiling((decimal)totalProducts / (decimal)this.RowPerPage);
		}

        public Product GetProduct(int Id)
		{
			return this.dbContext.ExecSingle<Product>("spSelectProductById", new { Id = Id });
		}
    }
}

