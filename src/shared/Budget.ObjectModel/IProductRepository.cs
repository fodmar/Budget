using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.ObjectModel
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAll();

        Task<Product> Insert(Product product);

        Task Update(Product product);

        Task Delete(Product product);
    }
}
