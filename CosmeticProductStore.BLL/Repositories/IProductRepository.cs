using CosmeticProductStore.BLL.Models;
using CosmeticProductStore.DAL.Data.Models;

namespace CosmeticProductStore.BLL.Repositories;

public interface IProductRepository 
{
    Product GetProductById(int id);
    void CreateProduct(CreateProduct product);
}
