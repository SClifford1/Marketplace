using System.Collections.Generic;
using Models;

namespace Services
{
    public interface IProductService
    {
        Product Get(int _id);
        IList<Product> GetAll();
        bool Add(Product _product);
        bool Update(int _id, Product _product);
        bool Delete(int _id);
    }
}
