using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Models;
using Repositories;

namespace Services
{
    public class ProductService : IProductService
    {
        private readonly ILogger m_logger;
        private readonly MarketplaceContext m_dbContext;

        public ProductService(ILogger<ProductService> _logger, MarketplaceContext _context)
        {
            m_logger = _logger;
            m_dbContext = _context;
        }

        public Product Get(int _id)
        {
            return m_dbContext.Products.FirstOrDefault(x => x.Id == _id);
        }

        public IList<Product> GetAll()
        {
            return m_dbContext.Products.ToList();
        }

        public bool Add(Product _product)
        {
            _product.Id = 0;
            m_dbContext.Products.Add(_product);
            return m_dbContext.SaveChanges() > 0;
        }

        public bool Update(int _id, Product _product)
        {
            var product = Get(_id);

            if (product == null) return false;

            if (!string.IsNullOrEmpty(_product.Name))
            {
                product.Name = _product.Name;
            }
            if (_product.Price > 0)
            {
                product.Price = _product.Price;
            }
            m_dbContext.Products.Update(product);
            return m_dbContext.SaveChanges() > 0;
        }

        public bool Delete(int _id)
        {
            var product = Get(_id);
            if (product == null) return false;
            m_dbContext.Products.Remove(product);
            return m_dbContext.SaveChanges() > 0;
        }
    }
}
