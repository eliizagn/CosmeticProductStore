using CosmeticProductStore.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmeticProductStore.BLL.Repositories;

public interface IProductRepository
{
    Product GetProductById(int id);
    void CreateProduct(Product product);
}
