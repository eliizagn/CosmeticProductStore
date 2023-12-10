using CosmeticProductStore.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmeticProductStore.BLL.Repositories;

public interface IStockItem
{
    StockItem GetStorewithProducts(string name);
    StockItem CreateStoreWithProducts(List<Store> stores, List<Product> products);
    
}
